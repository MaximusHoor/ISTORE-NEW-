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
    public class AddressService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddressService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationDetail> CreateAsync(Address entity)
        {
            var res = await _unitOfWork.AddressRepository.CreateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return res;
        }

        public async Task<IReadOnlyCollection<Address>> FindByConditionAsync(Expression<Func<Address, bool>> predicat)
        {
            return await _unitOfWork.AddressRepository.FindByConditionAsync(predicat);
        }

        public async Task<IReadOnlyCollection<Address>> GetAllAsync()
        {
            return await _unitOfWork.AddressRepository.GetAllAsync();
        }
    }
}
