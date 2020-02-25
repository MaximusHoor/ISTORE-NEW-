using Domain.EF_Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interfaces
{
    public interface IDeliveryRepository
    {
        Task<IReadOnlyCollection<Delivery>> FindByConditionWithIncludeAsync(Expression<Func<Delivery, bool>> predicat, Expression<Func<Delivery, bool>> includePredicat);
    }
}
