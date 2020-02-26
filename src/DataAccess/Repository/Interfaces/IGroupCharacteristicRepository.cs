using Domain.EF_Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interfaces
{
    public interface IGroupCharacteristicRepository
    {
        Task<IReadOnlyCollection<GroupCharacteristic>> FindByConditionWithIncludeAsync(Expression<Func<GroupCharacteristic, bool>> predicat, Expression<Func<GroupCharacteristic, bool>> includePredicat);
    }
}
