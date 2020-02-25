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
    public class CategoryRepository : BaseRepository<Category>
    {
       
        public CategoryRepository(StoreContext context) : base(context)
        {
            
        }

        public override async Task<IReadOnlyCollection<Category>> GetAllAsync()
        {
            return await this.Entities.Include(t => t.Title).Include(p => p.PreviewImage).Include(p => p.Products)
                .Include(s => s.Subcategories).ToListAsync().ConfigureAwait(false);
        }

        public override async Task<IReadOnlyCollection<Category>> FindByConditionAsync(Expression<Func<Category, bool>> predicat)
        {
            return await this.Entities.Include(t => t.Title).Include(p => p.PreviewImage).Include(p => p.Products)
                .Include(s => s.Subcategories).Where(predicat).ToListAsync().ConfigureAwait(false);
        } 

        //public async Task<OperationDetail> AddProductAsync(Category product)
        //{
        //    //(await _storeContext.Categories.FirstOrDefaultAsync(x => x.Id == categoryId)).Products.Add(product);
        //    //return new OperationDetail() { Message = "Product added" };
        //    return Create(product);
        //}
        //public async Task<OperationDetail> AddSubcategoryAsync(int categoryId, Category category)
        //{
        //    (await storeContext.Categories.FirstOrDefaultAsync(x => x.Id == categoryId)).Subcategories.Add(category);
        //    return new OperationDetail() { Message = "Subcategory added" };
        //}
    }
}
