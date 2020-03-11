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

        public async Task SaveGroupAsync(IEnumerable<GroupCharacteristic> groups)  
        {
            foreach(var group in groups)
            {
                var gr = await _unitOfWork.GroupCharacteristicRepository.GetByIdAsync(group.Id);
                
                if(gr is null)
                {
                    await _unitOfWork.GroupCharacteristicRepository.CreateAsync(group);
                    await this._unitOfWork.SaveChangesAsync();
                    gr = await _unitOfWork.GroupCharacteristicRepository.GetByIdAsync(group.Id);                    
                }
                else
                {
                    gr.Characteristics = group.Characteristics;
                    gr.ProductId = group.ProductId;
                    gr.Title = group.Title;
                }

                foreach(var character in group.Characteristics)
                {
                    var charac = await _unitOfWork.CharacteristicRepository.GetByIdAsync(character.Id);

                    if(charac is null)
                    {
                        await _unitOfWork.CharacteristicRepository.CreateAsync(character);
                        await this._unitOfWork.SaveChangesAsync();
                    }
                    else
                    {
                        charac.GroupCharacteristicId = gr.Id;
                        charac.Title = character.Title;
                        charac.Value = character.Value;
                    }
                }
            }

            await this._unitOfWork.SaveChangesAsync();
        }
    }
}
