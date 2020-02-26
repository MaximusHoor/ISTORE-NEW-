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
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
   public class DeliveryRepository : BaseRepository<Delivery>, IDeliveryRepository
    {
        public DeliveryRepository(StoreContext context) : base(context)
        {
        }

        public override async Task<IReadOnlyCollection<Delivery>> GetAllAsync()
        {
            return await this.Entities.Include(del=>del.AddressDelivery).ToListAsync().ConfigureAwait(false);
        }

        public override async Task<IReadOnlyCollection<Delivery>> FindByConditionAsync(Expression<Func<Delivery, bool>> predicat)
        {
            return await this.Entities.Include(del=>del.AddressDelivery)
                .Where(predicat).ToListAsync().ConfigureAwait(false);
        }

        public async Task<IReadOnlyCollection<Delivery>> FindByConditionWithIncludeAsync(Expression<Func<Delivery, bool>> predicat, Expression<Func<Delivery, bool>> includePredicat)
        {
            return await this.Entities.Include(includePredicat).Where(predicat).ToListAsync().ConfigureAwait(false);
        }
    }
}
