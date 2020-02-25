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
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<OperationDetail> AddOrderAsync(Order order)
        {
            var res = _unitOfWork.OrderRepository.CreateOrder(order);
            await _unitOfWork.SaveChangesAsync();
            return res;
        }

        public async Task<OperationDetail> DeleteOrderAsync(Order order)
        {
            var res = _unitOfWork.OrderRepository.DeleteOrder(order);
            await _unitOfWork.SaveChangesAsync().ConfigureAwait(false);
            return res;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _unitOfWork.OrderRepository.FindAllOrdersAsync();
        }

        public async Task<IEnumerable<Order>> GetOrderAsync(Expression<Func<Order, bool>> predicate)
        {
            return await _unitOfWork.OrderRepository.FindOrdersByConditionAsync(predicate);
        }

        public async Task<OperationDetail> UpdateOrderAsync(Order order)
        {
            var res = _unitOfWork.OrderRepository.UpdateOrder(order);
            await _unitOfWork.SaveChangesAsync();
            return res;
        }
    }
}
