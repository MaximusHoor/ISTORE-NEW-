using Domain.EF_Models;
using Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Business.Service
{
    public interface ICategoryService
    {
        Task<OperationDetail> AddCategoryAsync(Category category);
        Task<OperationDetail> DeleteCategoryAsync(Category category);
        Task<OperationDetail> UpdateCategoryAsync(Category category);
        Task<IEnumerable<Category>> FindAllCategoriesAsync();
        Task<IEnumerable<Category>> FindCategoryByConditionAsync(Expression<Func<Category, bool>> predicate);
    }
}