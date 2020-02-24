using DataAccess.Repository.Interfaces;
using Domain.Context;
using Domain.EF_Models;
using Domain.Infrastructure;
using Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class BrandRepository : BaseRepository<Brand>, IBrandRepository
    {
        public BrandRepository(StoreContext context) : base(context)
        {

        }

        public OperationDetail CreateBrand(Brand brand)
        {
            return Create(brand);
        }

        public OperationDetail DeleteBrand(Brand brand)
        {
            return Delete(brand);
        }

        public async Task<IEnumerable<Brand>> FindAllBrandsAsync()
        {
            return await FindAll().ToListAsync();
        }

        public async Task<IEnumerable<Brand>> FindBrandByConditionAsync(Expression<Func<Brand, bool>> predicate)
        {
            return await FindByCondition(predicate).ToListAsync();
        }

        public OperationDetail UpdateBrand(Brand brand)
        {
            return Update(brand);
        }
    }
}
