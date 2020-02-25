using Domain.EF_Models;
using Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Business.Service.Interfaces
{
    public interface ICharacteristicService
    {
        Task<OperationDetail> AddCharacteristicAsync(Characteristic characteristic);
        Task<OperationDetail> DeleteCharacteristicAsync(Characteristic characteristic);
        Task<OperationDetail> UpdateCharacteristicAsync(Characteristic characteristic);
        Task<IEnumerable<Characteristic>> GetCharacteristicAsync(Expression<Func<Characteristic, bool>> predicate);
        Task<IEnumerable<Characteristic>> GetAllCharacteristicsAsync();
    }
}
