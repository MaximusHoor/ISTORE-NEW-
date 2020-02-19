using Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.Interfaces
{
    public interface IDeliveryService<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllByConditionAsync(Expression<Func<T, bool>> predicat);
        Task<OperationDetail> CreateDeliveryAsync(T obj);
        Task<OperationDetail> UpdateDeliveryAsync(T obj);
        Task<OperationDetail> DeleteDeliveryAsync(T obj);
        Task<T> GetByConditionAsync(Expression<Func<T, bool>> predicat);

        //
        
    }
}
