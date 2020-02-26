using Domain.EF_Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interfaces
{
    public interface IOrderDetailsRepository
    {
        Task<IReadOnlyCollection<OrderDetails>> FindByConditionWithIncludeAsync(Expression<Func<OrderDetails, bool>> predicat, Expression<Func<OrderDetails, bool>> includePredicat);
    }
}
