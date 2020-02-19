using Domain.EF_Models;
using Domain.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interfaces
{
    public interface IOrderDetailsRepository : IRepository<OrderDetails>
    {
        Task<IEnumerable<OrderDetails>> FindAllOrderDetailsAsync();
        Task<IEnumerable<OrderDetails>> FindOrderDetailsByConditionAsync(Expression<Func<Package, bool>> predicate);
        Task<Order> GetOrderByOrderDetails(OrderDetails orderDetails);
        Task<Product> GetProductByOrderDetails(OrderDetails orderDetails);
    }
}
