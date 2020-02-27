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
            return await this.Entities.Include(x=>x.Delivery)
                .Include(x=>x.Products)
                .Include(x=>x.User)
                .ToListAsync().ConfigureAwait(false);
        }

        public override async Task<IReadOnlyCollection<Order>> FindByConditionAsync(Expression<Func<Order, bool>> predicat)
        {
            return await this.Entities.Include(x => x.Delivery)
                .Include(x => x.Products)
                .Include(x => x.User)
                .Where(predicat).ToListAsync().ConfigureAwait(false);
        }

        
    }
}