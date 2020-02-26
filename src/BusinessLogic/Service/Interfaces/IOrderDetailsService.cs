﻿using Domain.EF_Models;
using Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.Interfaces
{
    public interface IOrderDetailsService:ICrudService<OrderDetails>
    {
        Task<IReadOnlyCollection<OrderDetails>> FindByConditionWithIncludeAsync(Expression<Func<OrderDetails, bool>> predicat, Expression<Func<OrderDetails, bool>> includePredicat);
    }
}