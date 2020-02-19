using Domain.EF_Models;
using Domain.Infrastructure;
using Domain.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interfaces
{
    public interface IDeliveryRepository:IRepository<Delivery>
    {
        Task<IEnumerable<Delivery>> GetAllAsync();
        Task<IEnumerable<Delivery>> GetAllByConditionAsync(Expression<Func<Delivery, bool>> predicat);
        Task<OperationDetail> CreateDeliveryAsync(Delivery delivery);
        Task<OperationDetail> UpdateDeliveryAsync(Delivery delivery);
        Task<OperationDetail> DeleteDeliveryAsync(Delivery delivery);
        Task<Delivery> GetByConditionAsync(Expression<Func<Delivery, bool>> predicat);
    }
}
