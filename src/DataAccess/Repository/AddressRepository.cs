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
    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        public AddressRepository(StoreContext context) : base(context)
        {

        }

        public OperationDetail CreateAddress(Address address)
        {
            return Create(address);
        }

        public OperationDetail DeleteAddress(Address address)
        {
            return Delete(address);
        }

        public async Task<IEnumerable<Address>> FindAllAddressesAsync()
        {
            return await FindAll().ToListAsync();
        }

        public async Task<IEnumerable<Address>> FindAddressByConditionAsync(Expression<Func<Address, bool>> predicate)
        {
            return await FindByCondition(predicate).ToListAsync();
        }

        public OperationDetail UpdateAddress(Address address)
        {
            return Update(address);
        }
    }
}
