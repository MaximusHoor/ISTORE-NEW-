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
    public class OrderService 
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async  Task<OperationDetail> CreateAsync(Order entity)
        {
            var res = await _unitOfWork.OrderRepository.CreateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return res;
        }

        public async Task<IReadOnlyCollection<Order>> FindByConditionAsync(Expression<Func<Order, bool>> predicat)
        {
            return await _unitOfWork.OrderRepository.FindByConditionAsync(predicat);
        }
        

        public async Task<IReadOnlyCollection<Order>> GetAllAsync()
        {
            return await _unitOfWork.OrderRepository.GetAllAsync();
        }
    }
}
