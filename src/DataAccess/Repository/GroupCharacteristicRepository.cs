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
    public class GroupCharacteristicRepository : BaseRepository<GroupCharacteristic>, IGroupCharacteristicRepository
    {
        public GroupCharacteristicRepository(StoreContext context) : base(context)
        {

        }

        public override async Task<IReadOnlyCollection<GroupCharacteristic>> GetAllAsync()
        {
            return await this.Entities.Include(grc => grc.Product)
                .Include(grc => grc.Characteristics)
                .ToListAsync().ConfigureAwait(false);
        }

        public override async Task<IReadOnlyCollection<GroupCharacteristic>> FindByConditionAsync(Expression<Func<GroupCharacteristic, bool>> predicat)
        {
            return await this.Entities.Include(grc => grc.Product)
                .Include(grc => grc.Characteristics)
                .Where(predicat).ToListAsync().ConfigureAwait(false);
        }

        public async Task<IReadOnlyCollection<GroupCharacteristic>> FindByConditionWithIncludeAsync(Expression<Func<GroupCharacteristic, bool>> predicat, Expression<Func<GroupCharacteristic, bool>> includePredicat)
        {
            return await this.Entities.Include(includePredicat).Where(predicat).ToListAsync().ConfigureAwait(false);
        }
    }
}
