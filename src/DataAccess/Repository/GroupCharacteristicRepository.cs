using DataAccess.Repository.Interfaces;
using Domain.Context;
using Domain.EF_Models;
using Domain.Infrastructure;
using Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class GroupCharacteristicRepository : BaseRepository<GroupCharacteristic>, IGroupCharacteristicRepository
    {
        public GroupCharacteristicRepository(StoreContext context) : base(context)
        {

        }

        public OperationDetail CreateGroupCharacteristic(GroupCharacteristic groupCharacteristic)
        {
            return Create(groupCharacteristic);
        }

        public OperationDetail DeleteGroupCharacteristic(GroupCharacteristic groupCharacteristic)
        {
            return Delete(groupCharacteristic);
        }

        public async Task<IEnumerable<GroupCharacteristic>> FindAllGroupCharacteristicsAsync()
        {
            return await FindAll().ToListAsync();
        }

        public async Task<IEnumerable<GroupCharacteristic>> FindGroupCharacteristicByConditionAsync(Expression<Func<GroupCharacteristic, bool>> predicate)
        {
            return await FindByCondition(predicate).ToListAsync();
        }

        public OperationDetail UpdateGroupCharacteristic(GroupCharacteristic groupCharacteristic)
        {
            return Update(groupCharacteristic);
        }
    }
}
