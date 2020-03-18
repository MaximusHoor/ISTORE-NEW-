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

    public class ProductCharacteristicService 
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductCharacteristicService(IUnitOfWork unitOfWork)
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

        public async Task<ProductCharacteristic> GetByIdAsync (int id)
        {
            return await _unitOfWork.ProductCharacteristicRepository.GetByIdAsync(id);
        }

        //public async Task SaveGroupAsync(IEnumerable<ProductCharacteristic> groups)  
        //{
        //    foreach(var group in groups)
        //    {
        //        var gr = await _unitOfWork.ProductCharacteristicRepository.GetByIdAsync(group.Id);
                
        //        if(gr is null)
        //        {
        //            await _unitOfWork.ProductCharacteristicRepository.CreateAsync(group);
        //            await this._unitOfWork.SaveChangesAsync();
        //            gr = await _unitOfWork.ProductCharacteristicRepository.GetByIdAsync(group.Id);                    
        //        }
        //        else
        //        {
        //            gr.Characteristics = group.Characteristics;
        //            gr.ProductId = group.ProductId;
        //            gr.Descriptions = group.Descriptions;
        //        }

        //        foreach(var character in group.Characteristics)
        //        {
        //            var charac = await _unitOfWork.CharacteristicRepository.GetByIdAsync(character.Id);

        //            if(charac is null)
        //            {
        //                await _unitOfWork.CharacteristicRepository.CreateAsync(character);
        //                await this._unitOfWork.SaveChangesAsync();
        //            }
        //            else
        //            {
        //                charac.ProductCharacteristicId = gr.Id;
        //                charac.Title = character.Title;
        //                charac.Value = character.Value;
        //            }
        //        }
        //    }

        //    await this._unitOfWork.SaveChangesAsync();
        //}
    }
}
