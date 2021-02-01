using System;
using System.Linq;
using System.Linq.Expressions;
using Collections.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Services.Abstractions.Interfaces;

namespace Services.Abstractions
{
    public class BaseCrudService<T> : ICrudService<T> where T: BaseEntity
    {
        public BaseCrudService(DbContext context){
            Context = context;
            Set = Context.Set<T>();
        }

        protected DbContext Context { get; }
        protected DbSet<T> Set { get; } 
        public virtual IQueryable<T> Get(){
            return Set.AsNoTracking();
        }

        public virtual T GetById(int id) => Get().FirstOrDefault(x=>x.Id.Equals(id));

        public virtual T Create(T entity){
            var entry = Set.Add(entity);
            Context.SaveChanges();
            return entry.Entity;
        }

        public virtual T Update(T entity){
            var oldExist = Set.Any(x => x.Id.Equals(entity.Id));
            if (!oldExist) return null;
            Set.Attach(entity);
            var entry = Set.Update(entity);
            Context.SaveChanges();

            return entry.Entity;
        }

        public virtual void Delete(params int[] ids){
            Delete(x => ids.Contains(x.Id));
        }

        public virtual void Delete(Expression<Func<T, bool>> predicate){
            Set.RemoveRange(Set.Where(predicate));
            Context.SaveChanges();
        }
    }
}