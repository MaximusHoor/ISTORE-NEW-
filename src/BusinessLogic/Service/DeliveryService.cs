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
    public class DeliveryService : IDeliveryService
    {
        private readonly IUnitOfWork _unitOfWork;
       
        public DeliveryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;           
        }

        public async Task<OperationDetail> CreateAsync(Delivery entity)
        {
            var res = await _unitOfWork.DeliveryRepository.CreateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return res;
        }

        public async Task<IReadOnlyCollection<Delivery>> FindByConditionAsync(Expression<Func<Delivery, bool>> predicat)
        {
            return await _unitOfWork.DeliveryRepository.FindByConditionAsync(predicat);
        }

        public async Task<IReadOnlyCollection<Delivery>> FindByConditionWithIncludeAsync(Expression<Func<Delivery, bool>> predicat, Expression<Func<Delivery, bool>> includePredicat)
        {
            return await _unitOfWork.DeliveryRepository.FindByConditionWithIncludeAsync(predicat, includePredicat);
        }

        public async Task<IReadOnlyCollection<Delivery>> GetAllAsync()
        {
            return await _unitOfWork.DeliveryRepository.GetAllAsync();
        }
    }
}
