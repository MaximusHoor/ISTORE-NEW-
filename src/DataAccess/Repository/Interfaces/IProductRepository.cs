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
    public interface IProductRepository : IRepository<Product>
    {
        // Task<OperationDetail> AddImage(Product products,Image image);
        //Task<Brand> GetBrand(Product products);
        // Task<ICollection<Image>> GetAllImage(Product product);
        // Task<Image> GetImage(Product product);
        // Task<Category> GetCategory(Product product);
        // Task<Package> GetPackage(Product product);
        // OperationDetail AddComment(Product products, Comment comment);

        Task<IEnumerable<Product>> FindAllProductAsync();
        Task<IEnumerable<Product>> FindProductByConditionAsync(Expression<Func<Product, bool>> predicate);
        OperationDetail CreateProduct(Product product);
        OperationDetail UpdateProduct(Product product);
        OperationDetail DeleteProduct(Product product);


    }
}
