using DataAccess.Repository.Interfaces;
using Domain.Context;
using Domain.EF_Models;
using Domain.Infrastructure;
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
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(StoreContext context) : base(context)
        {
        }
        public OperationDetail CreateOrder(Order order)
        {
            return Create(order);
        }

        public OperationDetail UpdateOrder(Order order)
        {
            return Update(order);
        }

        public OperationDetail DeleteOrder(Order order)
        {
            return Delete(order);
        }
        public async Task<IEnumerable<Order>> FindAllOrdersAsync()
        {
            return await FindAll().ToListAsync(); throw new NotImplementedException();
        }

        public async Task<IEnumerable<Order>> FindOrdersByConditionAsync(Expression<Func<Order, bool>> predicate)
        {
            return await FindByCondition(predicate).ToListAsync();
        }

        //public async Task<Delivery> GetDeliveryByOrderAsync(Order order)
        //{
        //    Log.Information($"{DateTime.Now} - GetDeliveryByOrderAsync");
        //    return (await FindByCondition(x => x.Id == order.Id).FirstOrDefaultAsync()).Delivery;
        //}

        //public async Task<ICollection<OrderDetails>> GetProductsByOrderAsync(Order order)
        //{
        //    Log.Information($"{DateTime.Now} - GetDeliveryByOrderAsync");
        //    return (await FindByCondition(x => x.Id == order.Id).FirstOrDefaultAsync()).Products;
        //}

        //public async Task<User> GetUserByOrderAsync(Order order)
        //{
        //    Log.Information($"{DateTime.Now} - GetDeliveryByOrderAsync");
        //    return (await FindByCondition(x => x.Id == order.Id).FirstOrDefaultAsync()).User;
        //}

        //public async Task<OperationDetail> AddOrderDetailsToOrderAsync(Order order, OrderDetails orderDetails)
        //{
        //    Log.Information($"{DateTime.Now} - AddOrderDetailsToOrderAsync");
        //    (await FindByCondition(x => x.Id == order.Id).FirstOrDefaultAsync()).Products.Add(orderDetails);
        //    return new OperationDetail() { IsError = false, Message = "AddOrderDetailsToOrderAsync is OK" };
        //}

        //public async Task<OperationDetail> RemoveOrderDetailsOfOrderAsync(Order order, OrderDetails orderDetails)
        //{
        //    Log.Information($"{DateTime.Now} - GetDeliveryByOrderAsync");
        //    (await FindByCondition(x => x.Id == order.Id).FirstOrDefaultAsync()).Products.Remove(orderDetails);
        //    return new OperationDetail() { IsError = false, Message = "RemoveOrderDetailsOfOrderAsync is OK" };
        //}

    }
}