using DataAccess.Repository.Interfaces;
using Domain.Context;
using Domain.EF_Models;
using Domain.Infrastructure;
using Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private StoreContext _StoreContext { get; set; }

        public ProductRepository(StoreContext context) : base(context)
        {
            _StoreContext = context;
        }

        //public async Task<OperationDetail> AddImage(Product product, Image image)
        //{
        // (await  _StoreContext.Products.FirstOrDefaultAsync(x => x == product)).Images.Add(image);
        //    return  new OperationDetail() { Message = "AddImage Ok" };
        //}

        //public Task<Brand> GetBrand(Product products)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<ICollection<Image>> GetAllImage(Product product)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<Image> GetImage(Product product)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<Category> GetCategory(Product product)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<Package> GetPackage(Product product)
        //{
        //    throw new NotImplementedException();
        //}

        //public OperationDetail AddComment(Product products, Comment comment)
        //{
        //    throw new NotImplementedException();
        //}


        public async Task<IEnumerable<Product>> FindAllProductAsync()
        {
            return await FindAll().ToListAsync();
        }
        public async Task<IEnumerable<Product>> FindProductByConditionAsync(Expression<Func<Product, bool>> predicate)
        {
            return await FindByCondition(predicate).ToListAsync();
        }


        public OperationDetail CreateProduct(Product product)
        {
            return Create(product);
        }

        public OperationDetail UpdateProduct(Product product)
        {
            return Update(product);
        }

        public OperationDetail DeleteProduct(Product product)
        {
            return Delete(product);
        }
    }
}
