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
    public class CharacteristicRepository : BaseRepository<Characteristic>, ICharacteristicRepository
    { 
        public CharacteristicRepository(StoreContext context) : base(context)
        {

        }
        
        public override async Task<IReadOnlyCollection<Characteristic>> GetAllAsync()
        {
            return await this.Entities.Include(ch => ch.GroupCharacteristic).ToListAsync().ConfigureAwait(false);
        }

        public override async Task<IReadOnlyCollection<Characteristic>> FindByConditionAsync(Expression<Func<Characteristic, bool>> predicat)
        {
            return await this.Entities.Include(ch => ch.GroupCharacteristic).Where(predicat).ToListAsync().ConfigureAwait(false);
        }

        public async Task<Characteristic> GetByIdAsync(int id)
        {
            return await _storeContext.Characteristics.Where(x => x.Id == id)
                .Include(ch => ch.GroupCharacteristic).FirstOrDefaultAsync();
        }
    }
}
