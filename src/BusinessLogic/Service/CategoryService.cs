using DataAccess.UnitOfWork;
using Domain.EF_Models;
using Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service
{
    public class CategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public OperationDetail AddCategory(Category category)
        {
            var res = _unitOfWork.CategoryRepository.CreateCategory(category);
            _unitOfWork.SaveChangesAsync();
            return res;
        }

        public OperationDetail DeleteCategory(Category category)
        {
            var res = _unitOfWork.CategoryRepository.DeleteCategory(category);
            _unitOfWork.SaveChangesAsync();
            return res;
        }

        public OperationDetail UpdateCategory(Category category)
        {
            var res = _unitOfWork.CategoryRepository.UpdateCategory(category);
            _unitOfWork.SaveChangesAsync();
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
