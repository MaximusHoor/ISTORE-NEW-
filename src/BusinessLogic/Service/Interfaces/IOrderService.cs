using Domain.EF_Models;
using Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.Interfaces
{
    public interface IOrderService
    {
        Task<OperationDetail> AddOrderAsync(Order order);
        Task<IEnumerable<Order>> GetOrderAsync(Expression<Func<Order, bool>> predicate);
        Task<IEnumerable<Order>> GetAllOrdersAsync();
    }
}
