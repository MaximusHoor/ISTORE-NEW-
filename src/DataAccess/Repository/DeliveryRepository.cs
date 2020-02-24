using Domain.Context;
using Domain.EF_Models;
using Domain.Infrastructure;
using Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interfaces
{
    public class DeliveryRepository : BaseRepository<Delivery>, IDeliveryRepository
    {
        public DeliveryRepository(StoreContext context) : base(context)
        {
        }
        public OperationDetail CreateDelivery(Delivery delivery)
        {
            return Create(delivery);
        }
        public OperationDetail DeleteDelivery(Delivery delivery)
        {
            return Delete(delivery);
        }
        public async Task<IEnumerable<Delivery>> FindAllDeliveriesAsync()
        {
            return await FindAll().ToListAsync().ConfigureAwait(false);
        }
        public async Task<IEnumerable<Delivery>> FindDeliveryByConditionAsync(Expression<Func<Delivery, bool>> predicate)
        {
            return await FindByCondition(predicate).ToListAsync().ConfigureAwait(false);
        }
        public OperationDetail UpdateDelivery(Delivery delivery)
        {
            return Update(delivery);
        }
    }
}
