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

    public class GroupCharacteristicService : IGroupCharacteristicService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GroupCharacteristicService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public async Task<OperationDetail> AddGroupCharacteristicAsync(GroupCharacteristic groupCharacteristic)
        {
            var res = _unitOfWork.GroupCharacteristicRepository.CreateGroupCharacteristic(groupCharacteristic);
            await _unitOfWork.SaveChangesAsync();
            return res;
        }

        public async Task<OperationDetail> DeleteGroupCharacteristicAsync(GroupCharacteristic groupCharacteristic)
        {
            var res = _unitOfWork.GroupCharacteristicRepository.DeleteGroupCharacteristic(groupCharacteristic);
            await _unitOfWork.SaveChangesAsync();
            return res;
        }

        public async Task<OperationDetail> UpdateGroupCharacteristicAsync(GroupCharacteristic groupCharacteristic)
        {
            var res = _unitOfWork.GroupCharacteristicRepository.UpdateGroupCharacteristic(groupCharacteristic);
            await _unitOfWork.SaveChangesAsync();
            return res;
        }

        public async Task<IEnumerable<GroupCharacteristic>> GetGroupCharacteristicAsync(Expression<Func<GroupCharacteristic, bool>> predicate)
        {
            var groupCharacteristics = await _unitOfWork.GroupCharacteristicRepository.FindGroupCharacteristicByConditionAsync(predicate);
            return groupCharacteristics;
        }

        public async Task<IEnumerable<GroupCharacteristic>> GetAllGroupCharacteristicsAsync()
        {
            return await _unitOfWork.GroupCharacteristicRepository.FindAllGroupCharacteristicsAsync();
        }

        public async Task<IEnumerable<GroupCharacteristic>> FindByConditionWithInclude(Expression<Func<GroupCharacteristic, bool>> predicate, string property)
        {
           return _unitOfWork.GroupCharacteristicRepository.FindByConditionWithInclude(predicate, property);
        }
    }
}
