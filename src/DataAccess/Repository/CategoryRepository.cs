using DataAccess.Repository.Interfaces;
using Domain.Context;
using Domain.EF_Models;
using Domain.Infrastructure;
using Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
       
        public CategoryRepository(StoreContext context) : base(context)
        {
            
        }

        public override async Task<IReadOnlyCollection<Category>> GetAllAsync()
        {
            return await this.Entities.Include(p => p.Products)
                .Include(s => s.Subcategories)
                .ToListAsync().ConfigureAwait(false);
        }

        public override async Task<IReadOnlyCollection<Category>> FindByConditionAsync(Expression<Func<Category, bool>> predicat)
        {
            return await this.Entities.Include(p => p.Products)
                .Include(s => s.Subcategories)
                .Where(predicat).ToListAsync().ConfigureAwait(false);
        }

        public async Task<IReadOnlyCollection<Category>> FindByConditionWithIncludeAsync(Expression<Func<Category, bool>> predicat, Expression<Func<Category, bool>> includePredicat)
        {
            return await this.Entities.Include(includePredicat).Where(predicat).ToListAsync().ConfigureAwait(false);
        }
    }
}
