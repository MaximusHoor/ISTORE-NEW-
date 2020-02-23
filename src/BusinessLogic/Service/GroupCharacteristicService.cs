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
    public class GroupCharacteristicService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GroupCharacteristicService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public OperationDetail AddGroupCharacteristic(GroupCharacteristic groupCharacteristic)
        {
            var res = _unitOfWork.GroupCharacteristicRepository.CreateGroupCharacteristic(groupCharacteristic);
            _unitOfWork.SaveChangesAsync();
            return res;
        }

        public OperationDetail DeleteGroupCharacteristic(GroupCharacteristic groupCharacteristic)
        {
            var res = _unitOfWork.GroupCharacteristicRepository.DeleteGroupCharacteristic(groupCharacteristic);
            _unitOfWork.SaveChangesAsync();
            return res;
        }

        public OperationDetail UpdateGroupCharacteristic(GroupCharacteristic groupCharacteristic)
        {
            var res = _unitOfWork.GroupCharacteristicRepository.UpdateGroupCharacteristic(groupCharacteristic);
            _unitOfWork.SaveChangesAsync();
            return res;
        }

        public async Task<IEnumerable<GroupCharacteristic>> GetImage(Expression<Func<GroupCharacteristic, bool>> predicate)
        {
            var groupCharacteristics = await _unitOfWork.GroupCharacteristicRepository.FindGroupCharacteristicByConditionAsync(predicate);
            return groupCharacteristics;
        }

        public async Task<IEnumerable<GroupCharacteristic>> GetAllGroupCharacteristicsAsync()
        {
            return await _unitOfWork.GroupCharacteristicRepository.FindAllGroupCharacteristicsAsync();
        }
    }
}
