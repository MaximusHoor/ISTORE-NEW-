using Domain.EF_Models;
using Domain.Infrastructure;
using Domain.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interfaces
{
    public interface IGroupCharacteristicRepository : IRepository<GroupCharacteristic>
    {
        Task<IEnumerable<GroupCharacteristic>> FindAllGroupCharacteristicsAsync();
        Task<IEnumerable<GroupCharacteristic>> FindGroupCharacteristicByConditionAsync(Expression<Func<GroupCharacteristic, bool>> predicate);
        OperationDetail CreateGroupCharacteristic(GroupCharacteristic groupCharacteristic);
        OperationDetail UpdateGroupCharacteristic(GroupCharacteristic groupCharacteristic);
        OperationDetail DeleteGroupCharacteristic(GroupCharacteristic groupCharacteristic);
    }
}
