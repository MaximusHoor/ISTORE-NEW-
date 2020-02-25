     using Business.Service.Interfaces;
using DataAccess.UnitOfWork;
using Domain.EF_Models;
using Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service
{     
    public class AddressService: IAddressService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddressService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationDetail> AddAddressAsync(Address address)
        {
            var res = _unitOfWork.AddressRepository.CreateAddress(address);
            await _unitOfWork.SaveChangesAsync();
            return res;
        }

        public async Task<OperationDetail> DeleteAddressAsync(Address address)
        {
            var res = _unitOfWork.AddressRepository.DeleteAddress(address);
            await _unitOfWork.SaveChangesAsync();
            return res;
        }

        public async Task<IEnumerable<Address>> FindAddressByConditionAsync(Expression<Func<Address, bool>> predicate)
        {
            return await _unitOfWork.AddressRepository.FindAddressByConditionAsync(predicate);
        }

        public async Task<IEnumerable<Address>> FindAllAddressesAsync()
        {
            return await _unitOfWork.AddressRepository.FindAllAddressesAsync();
        }

        public async Task<OperationDetail> UpdateAddressAsync(Address address)
        {
            var res = _unitOfWork.AddressRepository.UpdateAddress(address);
            await _unitOfWork.SaveChangesAsync();
            return res;
        }
    }
}
