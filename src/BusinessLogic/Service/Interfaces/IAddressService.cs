using Domain.EF_Models;
using Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.Interfaces
{
    public interface IAddressService
    {
        Task<OperationDetail> AddAddressAsync(Address address);
        Task<OperationDetail> DeleteAddressAsync(Address address);
        Task<OperationDetail> UpdateAddressAsync(Address address);
        Task<IEnumerable<Address>> FindAllAddressesAsync();
        Task<IEnumerable<Address>> FindAddressByConditionAsync(Expression<Func<Address, bool>> predicate);
    }
}
