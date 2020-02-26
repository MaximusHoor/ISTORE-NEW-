using Domain.EF_Models;
using Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.Interfaces
{
    public interface IOrderService:ICrudService<Order>
    {
        Task<IReadOnlyCollection<Order>> FindByConditionWithIncludeAsync(Expression<Func<Order, bool>> predicat, Expression<Func<Order, bool>> includePredicat);
    }
}
