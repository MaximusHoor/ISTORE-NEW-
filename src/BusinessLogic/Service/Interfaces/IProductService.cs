﻿using Domain.EF_Models;
using Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.Interfaces
{
    public interface IProductService:ICrudService<Product>
    {
        Task<IReadOnlyCollection<Product>> FindByConditionWithIncludeAsync(Expression<Func<Product, bool>> predicat, Expression<Func<Product, bool>> includePredicat);
    }
}
