using Domain.EF_Models;
using Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Business.Service.Interfaces
{
    public interface IDeliveryService: ICrudService<Delivery>
    {
        Task<IReadOnlyCollection<Delivery>> FindByConditionWithIncludeAsync(Expression<Func<Delivery, bool>> predicat, Expression<Func<Delivery, bool>> includePredicat);
    }
}
