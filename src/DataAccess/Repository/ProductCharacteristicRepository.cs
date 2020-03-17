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
    public class ProductCharacteristicRepository : BaseRepository<ProductCharacteristic>, IProductCharacteristicRepository
    {
        public ProductCharacteristicRepository(StoreContext context) : base(context)
        {

        }

        public override async Task<IReadOnlyCollection<ProductCharacteristic>> GetAllAsync()
        {
            return await this.Entities.Include(grc => grc.Product)
                .Include(grc => grc.Characteristics)
                .ToListAsync().ConfigureAwait(false);
        }

        public override async Task<IReadOnlyCollection<ProductCharacteristic>> FindByConditionAsync(Expression<Func<ProductCharacteristic, bool>> predicat)
        {
            return await this.Entities.Include(grc => grc.Product)
                .Include(grc => grc.Characteristics)
                .Where(predicat).ToListAsync().ConfigureAwait(false);
        }

        public async Task<ProductCharacteristic> GetByIdAsync(int id)
        {
            return await _storeContext.ProductCharacteristics.Where(x=>x.Id==id)
                .Include(grc => grc.Product)
                .Include(grc => grc.Characteristics)
                .FirstOrDefaultAsync();
        }
    }
}
