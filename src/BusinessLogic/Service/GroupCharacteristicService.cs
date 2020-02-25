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
            var res = await _unitOfWork.GroupCharacteristicRepository.CreateAsync(groupCharacteristic)
                .ConfigureAwait(false);
            await _unitOfWork.SaveChangesAsync().ConfigureAwait(false);
            return res;
        }

        public async Task<IEnumerable<GroupCharacteristic>> GetAllGroupCharacteristicsAsync()
        {
            return await _unitOfWork.GroupCharacteristicRepository.GetAllAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<GroupCharacteristic>> GetGroupCharacteristicAsync(Expression<Func<GroupCharacteristic, bool>> predicate)
        {
            return await _unitOfWork.GroupCharacteristicRepository.FindByConditionAsync(predicate).ConfigureAwait(false);
        }
    }
}
