using Domain.EF_Models;
using Domain.Infrastructure;
using Domain.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<IEnumerable<Order>> FindAllOrdersAsync();
        Task<IEnumerable<Order>> FindOrdersByConditionAsync(Expression<Func<Order, bool>> predicate);
        Task<User> GetUserByOrderAsync(Order order);
        Task<Delivery> GetDeliveryByOrderAsync(Order order);
        Task<ICollection<OrderDetails>> GetProductsByOrderAsync(Order order);
        Task<OperationDetail> AddOrderDetailsToOrderAsync(Order order, OrderDetails orderDetails);
        Task<OperationDetail> RemoveOrderDetailsOfOrderAsync(Order order, OrderDetails orderDetails);
    }
}
