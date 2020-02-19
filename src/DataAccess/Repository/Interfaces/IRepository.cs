using System;
using System.Linq;
using System.Linq.Expressions;
using Domain.Infrastructure;

namespace Domain.Repository.Interfaces
{
    public interface IRepository<T>
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> predicat);
        OperationDetail Create(T entity);
        OperationDetail Update(T entity);
        OperationDetail Delete(T entity);
    }
}