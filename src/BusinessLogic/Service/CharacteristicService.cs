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

        public async Task<OperationDetail> CreateAsync(Characteristic entity)
        {
            var res = await _unitOfWork.CharacteristicRepository.CreateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return res;
        }

        public async Task<IReadOnlyCollection<Characteristic>> FindByConditionAsync(Expression<Func<Characteristic, bool>> predicat)
        {
            return await _unitOfWork.CharacteristicRepository.FindByConditionAsync(predicat);
        }

        public async Task<IReadOnlyCollection<Characteristic>> FindByConditionWithIncludeAsync(Expression<Func<Characteristic, bool>> predicat, Expression<Func<Characteristic, bool>> includePredicat)
        {
            return await _unitOfWork.CharacteristicRepository.FindByConditionWithIncludeAsync(predicat, includePredicat);
        }

        public async Task<IReadOnlyCollection<Characteristic>> GetAllAsync()
        {
            return await _unitOfWork.CharacteristicRepository.GetAllAsync();
        }
    }
}
