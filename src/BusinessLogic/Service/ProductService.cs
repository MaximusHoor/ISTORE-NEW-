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

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationDetail> AddProductAsync(Product product)
        {
            var res = _unitOfWork.ProductRepository.CreateProduct(product);
            await _unitOfWork.SaveChangesAsync();
            return res;
        }

        public async Task<OperationDetail> DeleteProductAsync(Product product)
        {
            var res = _unitOfWork.ProductRepository.DeleteProduct(product);
            await _unitOfWork.SaveChangesAsync();
            return res;
        }

        public async Task<IEnumerable<Product>> FindAllProductsAsync()
        {
            return await _unitOfWork.ProductRepository.FindAllProductAsync();
        }

        public async Task<IEnumerable<Product>> FindProductByConditionAsync(Expression<Func<Product, bool>> predicate)
        {
            return await _unitOfWork.ProductRepository.FindProductByConditionAsync(predicate);
        }

        public async Task<OperationDetail> UpdateProductAsync(Product product)
        {
            var res = _unitOfWork.ProductRepository.UpdateProduct(product);
            await _unitOfWork.SaveChangesAsync();
            return res;
        }
    }
}
