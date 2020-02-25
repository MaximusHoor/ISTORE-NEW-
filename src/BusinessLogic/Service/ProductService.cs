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
            var res = await _unitOfWork.ProductRepository.CreateAsync(product).ConfigureAwait(false);
             await _unitOfWork.SaveChangesAsync().ConfigureAwait(false);
            return res;
           
        }

        public async Task<IEnumerable<Product>> FindAllProductsAsync()
        {
            return await _unitOfWork.ProductRepository.GetAllAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<Product>> FindProductByConditionAsync(Expression<Func<Product, bool>> predicate)
        {
            return await _unitOfWork.ProductRepository.FindByConditionAsync(predicate).ConfigureAwait(false);
        }
    }
}
