﻿using Domain.EF_Models;
using Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.Interfaces
{
    public interface IProductService
    {
        Task<OperationDetail> AddProductAsync(Product product);
        Task<OperationDetail> DeleteProductAsync(Product product);
        Task<OperationDetail> UpdateProductAsync(Product product);
        Task<IEnumerable<Product>> FindAllProductsAsync();
        Task<IEnumerable<Product>> FindProductByConditionAsync(Expression<Func<Product, bool>> predicate);
    }
}
