using Domain.EF_Models;
using Domain.Infrastructure;
using Domain.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<IEnumerable<Category>> FindAllCategoriesAsync();
        Task<IEnumerable<Category>> FindCategoryByConditionAsync(Expression<Func<Category, bool>> predicate);
        OperationDetail CreateCategory(Category category);
        OperationDetail UpdateCategory(Category сategory);
        OperationDetail DeleteCategory(Category сategory); 
         

        //Task<OperationDetail> AddProductAsync(Product product);
        //Task<OperationDetail> AddSubcategoryAsync(Category category);
    }
}
