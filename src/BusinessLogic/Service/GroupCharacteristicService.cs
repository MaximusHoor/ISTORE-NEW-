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

    public class GroupCharacteristicService 
    {
        private readonly IUnitOfWork _unitOfWork;

        public GroupCharacteristicService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public async Task<OperationDetail> CreateAsync(GroupCharacteristic entity)
        {
            var res = await _unitOfWork.GroupCharacteristicRepository.CreateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return res;
        }

        public async Task<IReadOnlyCollection<GroupCharacteristic>> FindByConditionAsync(Expression<Func<GroupCharacteristic, bool>> predicat)
        {
            return await _unitOfWork.GroupCharacteristicRepository.FindByConditionAsync(predicat);
        }

        

        public async Task<IReadOnlyCollection<GroupCharacteristic>> GetAllAsync()
        {
            return await _unitOfWork.GroupCharacteristicRepository.GetAllAsync();
        }

        public async Task<GroupCharacteristic> GetByIdAsync (int id)
        {
            return await _unitOfWork.GroupCharacteristicRepository.GetByIdAsync(id);
        }
    }
}
