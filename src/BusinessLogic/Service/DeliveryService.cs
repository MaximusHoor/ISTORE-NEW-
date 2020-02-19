using Business.Service.Interfaces;
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
    public class DeliveryService:IDeliveryService<Delivery>
    {
        IUnitOfWork _unitOfWork;
        public DeliveryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationDetail> CreateDeliveryAsync(Delivery obj)
        {
            //return _unitOfWork.DeliveryRepository.Create(obj);
            return await _unitOfWork.DeliveryRepository.CreateDeliveryAsync(obj);
        }

        public async Task<OperationDetail> DeleteDeliveryAsync(Delivery obj)
        {
            //return _unitOfWork.DeliveryRepository.Create(obj);
            return await _unitOfWork.DeliveryRepository.DeleteDeliveryAsync(obj);
        }
        public async Task<OperationDetail> UpdateDeliveryAsync(Delivery obj)
        {
            return await _unitOfWork.DeliveryRepository.UpdateDeliveryAsync(obj);
        }

        public async Task<IEnumerable<Delivery>> GetAllAsync()
        {
            return await _unitOfWork.DeliveryRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Delivery>> GetAllByConditionAsync(Expression<Func<Delivery, bool>> predicat)
        {
            return await _unitOfWork.DeliveryRepository.GetAllByConditionAsync(predicat);
        }

        public async Task<Delivery> GetByConditionAsync(Expression<Func<Delivery, bool>> predicat)
        {
            return await _unitOfWork.DeliveryRepository.GetByConditionAsync(predicat);
        }

        
    }
}
