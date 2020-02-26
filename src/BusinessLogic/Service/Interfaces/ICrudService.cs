using Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Business.Service.Interfaces
{
    public interface ICrudService<T>
    {
        Task<IReadOnlyCollection<T>> GetAllAsync();
        Task<IReadOnlyCollection<T>> FindByConditionAsync(Expression<Func<T, bool>> predicat);
        Task<OperationDetail> CreateAsync(T entity);
    }
}
