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
    public interface IAddressRepository : IRepository<Address>
    {
        Task<IEnumerable<Address>> FindAllAddressesAsync();
        Task<IEnumerable<Address>> FindAddressByConditionAsync(Expression<Func<Address, bool>> predicate);
        OperationDetail CreateAddress(Address address);
        OperationDetail UpdateAddress(Address address);
        OperationDetail DeleteAddress(Address address);
    }
}
