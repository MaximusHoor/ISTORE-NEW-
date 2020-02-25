using Domain.EF_Models;
using Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Business.Service.Interfaces
{
    public interface IGroupCharacteristicService
    {
        Task<OperationDetail> AddGroupCharacteristicAsync(GroupCharacteristic groupCharacteristic);
        Task<OperationDetail> DeleteGroupCharacteristicAsync(GroupCharacteristic groupCharacteristic);
        Task<OperationDetail> UpdateGroupCharacteristicAsync(GroupCharacteristic groupCharacteristic);
        Task<IEnumerable<GroupCharacteristic>> GetGroupCharacteristicAsync(Expression<Func<GroupCharacteristic, bool>> predicate);
        Task<IEnumerable<GroupCharacteristic>> GetAllGroupCharacteristicsAsync();
        Task<IEnumerable<GroupCharacteristic>> FindByConditionWithInclude(Expression<Func<GroupCharacteristic, bool>> predicate, string property);
    }
}
