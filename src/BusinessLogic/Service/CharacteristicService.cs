using Business.Service.Interfaces;
using DataAccess.UnitOfWork;
using Domain.EF_Models;
using Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Business.Service
{

    public class CharacteristicService 
    {
        private readonly IUnitOfWork _unitOfWork;
        public CharacteristicService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationDetail> CreateAsync(ProductCharacteristic entity)
        {
            var res = await _unitOfWork.ProductCharacteristicRepository.CreateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return res;
        }

        public async Task<IReadOnlyCollection<ProductCharacteristic>> FindByConditionAsync(Expression<Func<ProductCharacteristic, bool>> predicat)
        {
            return await _unitOfWork.ProductCharacteristicRepository.FindByConditionAsync(predicat);
        }

      
        public async Task<IReadOnlyCollection<ProductCharacteristic>> GetAllAsync()
        {
            return await _unitOfWork.ProductCharacteristicRepository.GetAllAsync();
        }

        public async Task<ProductCharacteristic> GetByIdAsync(int id)
        {
            return await _unitOfWork.ProductCharacteristicRepository.GetByIdAsync(id);
        }
    }
}
