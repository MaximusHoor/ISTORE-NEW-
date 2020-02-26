using Domain.EF_Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interfaces
{
    public interface IOrderRepository
    {
        Task<IReadOnlyCollection<Order>> FindByConditionWithIncludeAsync(Expression<Func<Order, bool>> predicat, Expression<Func<Order, bool>> includePredicat);
    }
}
