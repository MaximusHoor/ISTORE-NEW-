using DataAccess.Repository.Interfaces;
using Domain.Context;
using Domain.EF_Models;
using Domain.Infrastructure;
using Domain.Repository.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        //public StoreContext storeContext { get; set; }
        public CategoryRepository(StoreContext context) : base(context)
        {
            //storeContext = context;
        }

        public async Task<IEnumerable<Category>> FindAllCategoriesAsync()
        {
            return await FindAll().ToListAsync();
        }
        public async Task<IEnumerable<Category>> FindCategoryByConditionAsync(Expression<Func<Category, bool>> predicate)
        {
            return await FindByCondition(predicate).ToListAsync();
        }
        public OperationDetail CreateCategory(Category category)
        {
            return Create(category);
        }
        public OperationDetail UpdateCategory(Category сategory)
        {
            return Update(сategory);
        }
        public OperationDetail DeleteCategory(Category сategory)
        {
            return Delete(сategory);
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
