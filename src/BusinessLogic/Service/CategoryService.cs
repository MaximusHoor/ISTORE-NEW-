using DataAccess.UnitOfWork;
using Domain.EF_Models;
using Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Business.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<OperationDetail> AddCategoryAsync(Category category)
        {
            var res = await _unitOfWork.CategoryRepository.CreateAsync(category).ConfigureAwait(false);
            await _unitOfWork.SaveChangesAsync().ConfigureAwait(false);
            return res;
        }

        public async Task<IEnumerable<Category>> FindAllCategoriesAsync()
        {                                  
            return await _unitOfWork.CategoryRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Category>> FindCategoryByConditionAsync(Expression<Func<Category, bool>> predicate)
        {
            return await _unitOfWork.CategoryRepository.FindByConditionAsync(predicate);
        }
    }
}
