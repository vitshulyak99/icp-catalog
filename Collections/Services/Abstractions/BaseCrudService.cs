using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Collections.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Services.Abstractions.Interfaces;
using Services.DTO;

namespace Services.Abstractions
{
    public abstract class BaseCrudService<T, TDto> : ICrudService<TDto> where T : BaseEntity where TDto : BaseDto
    {
        protected BaseCrudService(DbContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
            Set = context.Set<T>();
        }

        protected DbContext Context { get; }
        protected IMapper Mapper { get; }
        protected DbSet<T> Set { get; }
        
        protected abstract IQueryable<T> Include(IQueryable<T> query);
        protected IQueryable<TDto> ProjectTo(IQueryable query) => query.ProjectTo<TDto>(Mapper.ConfigurationProvider);

        public virtual IEnumerable<TDto> GetPage(int skip, int take) => ProjectTo(Include(Set.Skip(skip).Take(take))).ToList();

        public virtual IEnumerable<TDto> GetAll()
        {
            return ProjectTo(Include(Set)).ToList();
        }

        public virtual TDto GetById(int id) => ProjectTo(Include(Set.Where(x => x.Id.Equals(id)))).FirstOrDefault();

        public virtual TDto Create(TDto dto) => Mapper.Map(BaseCreate(Mapper.Map<T>(dto)),dto);

        protected virtual T BaseCreate(T entity)
        {
            var entry = Set.Add(entity);
            Context.SaveChanges();
            return entry.Entity;
        }
        
        public virtual TDto Update(TDto dto)
        {
            var old = Set.FirstOrDefault(x => dto.Id.Equals(x.Id));
            if (old is null) return null;
            Mapper.Map(dto, old);
            var result = Set.Update(old).Entity;
            Context.SaveChanges();   
            return Mapper.Map(result,dto);;
        }

        public virtual void Delete(params int[] ids)
        {
            DeleteBase(x=>ids.Contains(x.Id));
        }
        
        protected virtual void DeleteBase(Expression<Func<T, bool>> expression)
        {
            Context.Remove(Set.Where(expression));
            Context.SaveChanges();
        }
    }
}