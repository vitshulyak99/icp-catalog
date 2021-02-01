using System;
using System.Linq;
using System.Linq.Expressions;
using Collections.DAL.Entities;

namespace Services.Abstractions.Interfaces
{
    public interface ICrudService<T> where T: BaseEntity
    {
        IQueryable<T> Get();
        T GetById(int id);
        T Create(T entity);
        T Update(T entity);
        void Delete(params int[] ids);
        void Delete(Expression<Func<T, bool>> predicate);
    }
}
