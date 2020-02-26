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

        public async Task<OperationDetail> CreateAsync(Category entity)
        {
            var res = await _unitOfWork.CategoryRepository.CreateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return res;
        }

        public async Task<IReadOnlyCollection<Category>> FindByConditionAsync(Expression<Func<Category, bool>> predicat)
        {
            return await _unitOfWork.CategoryRepository.FindByConditionAsync(predicat);
        }

        public async Task<IReadOnlyCollection<Category>> FindByConditionWithIncludeAsync(Expression<Func<Category, bool>> predicat, Expression<Func<Category, bool>> includePredicat)
        {
            return await _unitOfWork.CategoryRepository.FindByConditionWithIncludeAsync(predicat, includePredicat);
        }

        public async Task<IReadOnlyCollection<Category>> GetAllAsync()
        {
            return await _unitOfWork.CategoryRepository.GetAllAsync();
        }
    }
}
