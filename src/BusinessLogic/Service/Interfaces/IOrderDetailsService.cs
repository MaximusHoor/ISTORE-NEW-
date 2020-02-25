using Domain.EF_Models;
using Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.Interfaces
{
    public interface IOrderDetailsService
    {
        Task<OperationDetail> AddOrderDetailsAsync(OrderDetails orderDetails);
        Task<OperationDetail> DeleteOrderDetailsAsync(OrderDetails orderDetails);
        Task<OperationDetail> UpdateOrderDetailsAsync(OrderDetails orderDetails);
        Task<IEnumerable<OrderDetails>> GetOrderDetailsAsync(Expression<Func<OrderDetails, bool>> predicate);
        Task<IEnumerable<OrderDetails>> GetAllOrderDetailsAsync();
    }
}
