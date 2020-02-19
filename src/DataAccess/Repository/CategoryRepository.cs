using DataAccess.Repository.Interfaces;
using Domain.Context;
using Domain.EF_Models;
using Domain.Infrastructure;
using Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public StoreContext storeContext { get; set; }
        public CategoryRepository(StoreContext context) : base(context)
        {
            storeContext = context;
        }
        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await FindAll().ToListAsync();
        }

        public async Task<OperationDetail> AddProductAsync(int categoryId, Product product)
        {
           
             (await storeContext.Categories.FirstOrDefaultAsync(x => x.Id == categoryId)).Products.Add(product);
            return new OperationDetail() { Message = "Product added" };
        }

        public async Task<OperationDetail> AddSubcategoryAsync(int categoryId, Category category)
        {
            (await storeContext.Categories.FirstOrDefaultAsync(x => x.Id == categoryId)).Subcategories.Add(category);
            return new OperationDetail() { Message = "Subcategory added" };
        }

        
    }
}
