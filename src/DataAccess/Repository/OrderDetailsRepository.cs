using DataAccess.Repository.Interfaces;
using Domain.Context;
using Domain.EF_Models;
using Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderDetailsRepository : BaseRepository<OrderDetails>, IOrderDetailsRepository
    {
        public OrderDetailsRepository(StoreContext context) : base(context)
        {
        }

        public async Task<IEnumerable<OrderDetails>> FindAllOrderDetailsAsync()
        {
            Log.Information($"{DateTime.Now} - FindAllOrderDetailsAsync");
            return await FindAll().ToListAsync();
        }

        public async Task<IEnumerable<OrderDetails>> FindOrderDetailsByConditionAsync(Expression<Func<Package, bool>> predicate)
        {
            Log.Information($"{DateTime.Now} - FindOrderDetailsByConditionAsync");
            return await FindAll().ToListAsync();
        }

        public async Task<Order> GetOrderByOrderDetails(OrderDetails orderDetails)
        {
            Log.Information($"{DateTime.Now} - GetOrderByOrderDetails");
            return (await FindByCondition(x => x.Id == orderDetails.Id).FirstOrDefaultAsync()).Order;
        }

        public async Task<Product> GetProductByOrderDetails(OrderDetails orderDetails)
        {
            Log.Information($"{DateTime.Now} - GetProductByOrderDetails");
            return (await FindByCondition(x => x.Id == orderDetails.Id).FirstOrDefaultAsync()).Product;
        }
    }
}
