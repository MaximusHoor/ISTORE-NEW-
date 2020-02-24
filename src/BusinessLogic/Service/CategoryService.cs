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
            var res = _unitOfWork.CategoryRepository.CreateCategory(category);
            await _unitOfWork.SaveChangesAsync();
            return res;
        }

        public async Task<OperationDetail> DeleteCategoryAsync(Category category)
        {
            var res = _unitOfWork.CategoryRepository.DeleteCategory(category);
            await _unitOfWork.SaveChangesAsync();
            return res;
        }

        public async Task<OperationDetail> UpdateCategoryAsync(Category category)
        {
            var res = _unitOfWork.CategoryRepository.UpdateCategory(category);
            await _unitOfWork.SaveChangesAsync();
            return res;
        }

        public async Task<IEnumerable<Category>> FindAllCategoriesAsync()
        {
            return await _unitOfWork.CategoryRepository.FindAllCategoriesAsync();
        }
        public async Task<IEnumerable<Category>> FindCategoryByConditionAsync(Expression<Func<Category, bool>> predicate)
        {
            var category = await _unitOfWork.CategoryRepository.FindCategoryByConditionAsync(predicate);
            return category;
        }
    }
}
