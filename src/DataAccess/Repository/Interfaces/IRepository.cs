using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Infrastructure;

namespace Domain.Repository.Interfaces
{
    public interface IRepository<T>
    {
        Task<IQueryable<T>> FindAllAsync();
        Task<IQueryable<T>> FindByConditionAsync(Expression<Func<T,bool>> predicat);
        Task<OperationDetail> Create(T entity);
        Task<OperationDetail> Update(T entity);
        Task<OperationDetail> Delete(T entity);
    }
}
