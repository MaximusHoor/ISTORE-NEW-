using Domain.EF_Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interfaces
{
    public interface ICharacteristicRepository
    {
        Task<IReadOnlyCollection<Characteristic>> FindByConditionWithIncludeAsync(Expression<Func<Characteristic, bool>> predicat, Expression<Func<Characteristic, bool>> includePredicat);
    }
}
