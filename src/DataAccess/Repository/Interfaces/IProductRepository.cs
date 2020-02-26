using Domain.EF_Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interfaces
{
    public interface IProductRepository
    {
        Task<IReadOnlyCollection<Product>> FindByConditionWithIncludeAsync(Expression<Func<Product, bool>> predicat, Expression<Func<Product, bool>> includePredicat);
    }
}
