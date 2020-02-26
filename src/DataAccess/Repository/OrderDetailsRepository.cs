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
    public class OrderDetailsRepository : BaseRepository<OrderDetails>, IOrderDetailsRepository
    {
        public OrderDetailsRepository(StoreContext context) : base(context)
        {
        }
        public override async Task<IReadOnlyCollection<OrderDetails>> GetAllAsync()
        {
            return await this.Entities.Include(x=>x.Order)
                .Include(x=>x.Product)
                .ToListAsync().ConfigureAwait(false);
        }

        public override async Task<IReadOnlyCollection<OrderDetails>> FindByConditionAsync(Expression<Func<OrderDetails, bool>> predicat)
        {
            return await this.Entities.Include(x => x.Order)
                .Include(x => x.Product)
                .Where(predicat).ToListAsync().ConfigureAwait(false);
        }

        public async Task<IReadOnlyCollection<OrderDetails>> FindByConditionWithIncludeAsync(Expression<Func<OrderDetails, bool>> predicat, Expression<Func<OrderDetails, bool>> includePredicat)
        {
            return await this.Entities.Include(includePredicat).Where(predicat).ToListAsync().ConfigureAwait(false);
        }
    }
}
