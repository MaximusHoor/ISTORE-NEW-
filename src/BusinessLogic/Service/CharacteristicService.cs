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

    public class CharacteristicService : ICharacteristicService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CharacteristicService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<OperationDetail> AddCharacteristicAsync(Characteristic characteristic)
        {
            var res = _unitOfWork.CharacteristicRepository.CreateCharacteristic(characteristic);
            await _unitOfWork.SaveChangesAsync();
            return res;
        }
        public async Task<OperationDetail> DeleteCharacteristicAsync(Characteristic characteristic)
        {
            var res = _unitOfWork.CharacteristicRepository.DeleteCharacteristic(characteristic);
            await _unitOfWork.SaveChangesAsync();
            return res;
        }

        public async Task<IEnumerable<Characteristic>> GetAllCharacteristicsAsync()
        {
            return await _unitOfWork.CharacteristicRepository.FindAllCharacteristicAsync();
        }

        public async Task<IEnumerable<Characteristic>> GetCharacteristicAsync(Expression<Func<Characteristic, bool>> predicate)
        {
            var characteristics = await _unitOfWork.CharacteristicRepository.FindCharacteristicByConditionAsync(predicate);
            return characteristics;
        }

        public async Task<OperationDetail> UpdateCharacteristicAsync(Characteristic characteristic)
        {
            var res = _unitOfWork.CharacteristicRepository.UpdateCharacteristic(characteristic);
            await _unitOfWork.SaveChangesAsync();
            return res;
        }
    }
}
