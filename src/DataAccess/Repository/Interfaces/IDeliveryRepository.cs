using Domain.EF_Models;
using Domain.Infrastructure;
using Domain.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interfaces
{
    public interface IDeliveryRepository : IRepository<Delivery>
    {
        Task<IEnumerable<Delivery>> FindAllDeliveriesAsync();
        Task<IEnumerable<Delivery>> FindDeliveryByConditionAsync(Expression<Func<Delivery, bool>> predicate);
        Task<OperationDetail> CreateDelivery(Delivery delivery);
        Task<OperationDetail> UpdateDelivery(Delivery delivery);
        Task<OperationDetail> DeleteDelivery(Delivery delivery);
    }
}
