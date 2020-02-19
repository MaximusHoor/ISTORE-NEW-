using Domain.Context;
using Domain.EF_Models;
using Domain.Infrastructure;
using Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interfaces
{
    public class DeliveryRepository : BaseRepository<Delivery>, IDeliveryRepository
    {
        public DeliveryRepository(StoreContext context) : base(context)
        {

        }

        public OperationDetail CreateComment(Delivery delivery)
        {
            return Create(delivery);
        }

        public OperationDetail DeleteComment(Delivery delivery)
        {
            return Delete(delivery);
        }

        public async Task<IEnumerable<Delivery>> FindAllCommentsAsync()
        {
            return await FindAll().ToListAsync();
        }

        public async Task<IEnumerable<Delivery>> FindCommentByConditionAsync(Expression<Func<Delivery, bool>> predicate)
        {
            return await FindByCondition(predicate).ToListAsync();
        }

        public OperationDetail UpdateComment(Delivery delivery)
        {
            return Update(delivery);
        }
    }
}
