using AutoMapper;
using Business.Infrastructure;
using Business.Service.Interfaces;
using DataAccess.UnitOfWork;
using Domain.EF_Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service
{
    public class DeliveryService : IDeliveryService<Delivery>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public DeliveryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OperationDetailDTO> Create(Delivery obj)
        {
            var result = _mapper.Map<OperationDetailDTO>(await _unitOfWork.DeliveryRepository.CreateDelivery(obj));
            await _unitOfWork.SaveChangesAsync();
            return result;
        }

        public async Task<OperationDetailDTO> Delete(Delivery obj)
        {
            var result = _mapper.Map<OperationDetailDTO>(await _unitOfWork.DeliveryRepository.DeleteDelivery(obj));
            await _unitOfWork.SaveChangesAsync();
            return result;
        }

        public async Task<IEnumerable<Delivery>> FindAll()
        {
            return _mapper.Map<IEnumerable<Delivery>>(await _unitOfWork.DeliveryRepository.FindAllDeliveriesAsync());
        }

        public async Task<IEnumerable<Delivery>> FindByCondition(Expression<Func<Delivery, bool>> predicat)
        {
            return _mapper.Map<IEnumerable<Delivery>>(await _unitOfWork.DeliveryRepository.FindDeliveryByConditionAsync(predicat));
        }

        public async Task<OperationDetailDTO> Update(Delivery obj)
        {
            var result = _mapper.Map<OperationDetailDTO>(await _unitOfWork.DeliveryRepository.UpdateDelivery(obj));
            await _unitOfWork.SaveChangesAsync();
            return result;
        }

        public Task<OperationDetailDTO> CustomMethod(Delivery obj)
        {
            throw new NotImplementedException();
        }
    }
}
