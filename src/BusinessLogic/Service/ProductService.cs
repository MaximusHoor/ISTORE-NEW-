using Business.Service.Interfaces;
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
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public async Task<OperationDetail> CreateAsync(Product entity)
        {
            var res = await _unitOfWork.ProductRepository.CreateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return res;
        }

        public async Task<IReadOnlyCollection<Product>> FindByConditionAsync(Expression<Func<Product, bool>> predicat)
        {
            return await _unitOfWork.ProductRepository.FindByConditionAsync(predicat);
        }

        public async Task<IReadOnlyCollection<Product>> FindByConditionWithIncludeAsync(Expression<Func<Product, bool>> predicat, Expression<Func<Product, bool>> includePredicat)
        {
            return await _unitOfWork.ProductRepository.FindByConditionWithIncludeAsync(predicat, includePredicat);
        }

        public async Task<IReadOnlyCollection<Product>> GetAllAsync()
        {
            return await _unitOfWork.ProductRepository.GetAllAsync();
        }
    }
}
