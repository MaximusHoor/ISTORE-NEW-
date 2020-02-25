using Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Business.Service.Interfaces
{
    public interface ICrudService<T>
    {
        Task<IEnumerable<T>> FindAllAsync();
        Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> predicat);
        Task<OperationDetail> CreateAsync(T obj);
        Task<OperationDetail> UpdateAsync(T obj);
        Task<OperationDetail> DeleteAsync(T obj);
    }
}
