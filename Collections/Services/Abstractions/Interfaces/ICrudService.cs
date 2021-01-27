using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Collections.DAL.Entities;

namespace Services.Abstractions.Interfaces
{
    public interface ICrudService<T> where T: BaseEntity
    {
        IEnumerable<T> Get();
        IEnumerable<TDto> Get<TDto>();
        T GetById(int id);
        TDto GetById<TDto>(int id);
        T Create(T entity);
        TDtoResult Create<TDtoSource,TDtoResult>(TDtoSource entity);
        T Update(T entity);
        TDto Update<TDto>(TDto entity);
        void Delete(params int[] ids);
        void Delete(Expression<Func<T, bool>> predicate);
    }
}
