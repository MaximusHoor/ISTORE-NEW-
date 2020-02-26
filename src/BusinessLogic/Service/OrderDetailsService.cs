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
    public class OrderDetailsService : IOrderDetailsService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderDetailsService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<OperationDetail> CreateAsync(OrderDetails entity)
        {
            var res = await _unitOfWork.OrderDetailsRepository.CreateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return res;
        }

        public async Task<IReadOnlyCollection<OrderDetails>> FindByConditionAsync(Expression<Func<OrderDetails, bool>> predicat)
        {
            return await _unitOfWork.OrderDetailsRepository.FindByConditionAsync(predicat);
        }

        public async Task<IReadOnlyCollection<OrderDetails>> FindByConditionWithIncludeAsync(Expression<Func<OrderDetails, bool>> predicat, Expression<Func<OrderDetails, bool>> includePredicat)
        {
            return await _unitOfWork.OrderDetailsRepository.FindByConditionWithIncludeAsync(predicat, includePredicat);
        }

        public async Task<IReadOnlyCollection<OrderDetails>> GetAllAsync()
        {
            return await _unitOfWork.OrderDetailsRepository.GetAllAsync();
        }
    }
}
