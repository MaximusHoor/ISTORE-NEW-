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
    public interface ICharacteristicRepository : IRepository<Characteristic>
    {
        Task<IEnumerable<Characteristic>> FindAllCharacteristicAsync();
        Task<IEnumerable<Characteristic>> FindCharacteristicByConditionAsync(Expression<Func<Characteristic, bool>> predicate);
        OperationDetail CreateCharacteristic(Characteristic characteristic);
        OperationDetail UpdateCharacteristic(Characteristic characteristic);
        OperationDetail DeleteCharacteristic(Characteristic characteristic); 
    }
    
    
}
