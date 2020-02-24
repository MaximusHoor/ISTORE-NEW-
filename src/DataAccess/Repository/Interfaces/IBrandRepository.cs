using Domain.EF_Models;
using Domain.Infrastructure;
using Domain.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interfaces
{
    public interface IBrandRepository : IRepository<Brand>
    {
        Task<IEnumerable<Brand>> FindAllBrandsAsync();
        Task<IEnumerable<Brand>> FindBrandByConditionAsync(Expression<Func<Brand, bool>> predicate);
        OperationDetail CreateBrand(Brand brand);
        OperationDetail UpdateBrand(Brand brand);
        OperationDetail DeleteBrand(Brand brand);
    }
}
