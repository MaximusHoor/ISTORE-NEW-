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

        public async Task<OperationDetail> AddOrderDetailsAsync(OrderDetails orderDetails)
        {
            var res = await _unitOfWork.OrderDetailsRepository.CreateAsync(orderDetails);
            await _unitOfWork.SaveChangesAsync();
            return res;
        }

        public async Task<IEnumerable<OrderDetails>> GetAllOrderDetailsAsync()
        {
            return await _unitOfWork.OrderDetailsRepository.GetAllAsync();
        }

        public async Task<IEnumerable<OrderDetails>> GetOrderDetailsAsync(Expression<Func<OrderDetails, bool>> predicate)
        {
            return await _unitOfWork.OrderDetailsRepository.FindByConditionAsync(predicate);
        }
    }
}
