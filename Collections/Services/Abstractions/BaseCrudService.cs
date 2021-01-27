using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Collections.DAL;
using Collections.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Services.Abstractions.Interfaces;

namespace Services.Abstractions
{
    public class BaseCrudService<T> : ICrudService<T> where T: BaseEntity
    {
        public BaseCrudService(AppDbContext context, IMapper mapper){
            Context = context;
            Set = Context.Set<T>();
            Mapper = mapper;
        }

        protected IMapper Mapper { get; }
        protected AppDbContext Context { get; }
        protected DbSet<T> Set { get; } 
        public virtual IEnumerable<T> Get(){
            return Set.AsNoTracking().ToArray();
        }

        public virtual IEnumerable<TDto> Get<TDto>() => Get().Select(Mapper.Map<TDto>);

        public virtual T GetById(int id){
          return Set.FirstOrDefault();
        }

        public TDto GetById<TDto>(int id) => Mapper.Map<TDto>(GetById(id));

        public virtual T Create(T entity){
            var entry = Set.Add(entity);
            Context.SaveChanges();
            return entry.Entity;
        }

        public TDtoResult Create<TDtoSource,TDtoResult>(TDtoSource entity) => Mapper.Map<TDtoResult>(Create(Mapper.Map<T>(entity)));

        public virtual T Update(T entity){
            var old = Set.FirstOrDefault(x => x.Id.Equals(entity.Id));
            if (old is null) return null;
            var entry = Set.Update(entity);
            Context.SaveChanges();

            return entry.Entity;
        }

        public TDto Update<TDto>(TDto entity) => Mapper.Map<TDto>(Update(Mapper.Map<T>(entity)));
        

        public virtual void Delete(params int[] ids){
            Delete(x => ids.Contains(x.Id));
        }

        public virtual void Delete(Expression<Func<T, bool>> predicate){
            Set.RemoveRange(Set.Where(predicate));
            Context.SaveChanges();
        }
    }
}