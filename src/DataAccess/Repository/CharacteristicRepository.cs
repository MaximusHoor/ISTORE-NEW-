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
    public class CharacteristicRepository : BaseRepository<Characteristic>/*, ICharacteristicRepository*/
    {
        public CharacteristicRepository(StoreContext context) : base(context)
        {

        }
        //public OperationDetail CreateCharacteristic(Characteristic characteristic)
        //{
        //    return Create(characteristic);
        //}
        //public OperationDetail DeleteCharacteristic(Characteristic characteristic)
        //{
        //    return Delete(characteristic);
        //}
        //public async Task<IEnumerable<Characteristic>> FindAllCharacteristicAsync()
        //{
        //    return await FindAll().ToListAsync();
        //}
        //public async Task<IEnumerable<Characteristic>> FindCharacteristicByConditionAsync(Expression<Func<Characteristic, bool>> predicate)
        //{
        //    return await FindByCondition(predicate).ToListAsync();
        //}

        //public OperationDetail UpdateCharacteristic(Characteristic characteristic)
        //{
        //    return Update(characteristic);
        //}
        public override async Task<IReadOnlyCollection<Characteristic>> GetAllAsync()
        {
            return await this.Entities.Include(x => x.GroupCharacteristic).ToListAsync().ConfigureAwait(false);
        }

        public override async Task<IReadOnlyCollection<Characteristic>> FindByConditionAsync(Expression<Func<Characteristic, bool>> predicat)
        {
            return await this.Entities.Include(x => x.GroupCharacteristic).Where(predicat).ToListAsync().ConfigureAwait(false);
        }


    }
}
