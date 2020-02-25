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
    public class DeliveryService : IDeliveryService<Delivery>
    {
        private readonly IUnitOfWork _unitOfWork;
       
        public DeliveryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;           
        }
        public async Task<IEnumerable<Delivery>> FindAllAsync()
        {
            return await _unitOfWork.DeliveryRepository.FindAllDeliveriesAsync();
        }
        public async Task<IEnumerable<Delivery>> FindByConditionAsync(Expression<Func<Delivery, bool>> predicat)
        {
            return await _unitOfWork.DeliveryRepository.FindDeliveryByConditionAsync(predicat);
        }
        public Task<OperationDetail> CustomMethod(Delivery obj)
        {
            throw new NotImplementedException();
        }
        public async Task<OperationDetail> CreateAsync(Delivery obj)
        {
            var result = _unitOfWork.DeliveryRepository.CreateDelivery(obj);
            await _unitOfWork.SaveChangesAsync();
            return result;
        }

        public async Task<OperationDetail> UpdateAsync(Delivery obj)
        {
            var result =  _unitOfWork.DeliveryRepository.UpdateDelivery(obj);
            await _unitOfWork.SaveChangesAsync();
            return result;
        }

        public async Task<OperationDetail> DeleteAsync(Delivery obj)
        {
            var result =  _unitOfWork.DeliveryRepository.DeleteDelivery(obj);
            await _unitOfWork.SaveChangesAsync();
            return result;
        }
    }
}
