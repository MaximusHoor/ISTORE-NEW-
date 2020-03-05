using DataAccess.Repository.Interfaces;
using Domain.Context;
using Domain.EF_Models;
using Domain.Infrastructure;
using Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderRepository : BaseRepository<Order>
    {
        public OrderRepository(StoreContext context) : base(context)
        {
        }
        public override async Task<IReadOnlyCollection<Order>> GetAllAsync()
        {
            var res = await this.Entities.Include(x => x.Delivery)
                .Include(x => x.Products).ThenInclude(y => y.Product)
                .Include(x => x.User)
                .ToListAsync().ConfigureAwait(false);
            return res;
        }

        public override async Task<IReadOnlyCollection<Order>> FindByConditionAsync(Expression<Func<Order, bool>> predicat)
        {
            var res = await this.Entities.Include(x => x.Delivery)
                .Include(x => x.Products).ThenInclude(y => y.Product)
                .Include(x => x.User)
                .Where(predicat).ToListAsync().ConfigureAwait(false);
            return res;
        }

        
    }
}