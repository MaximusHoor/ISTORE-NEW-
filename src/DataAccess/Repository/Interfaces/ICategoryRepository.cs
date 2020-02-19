using Domain.EF_Models;
using Domain.Infrastructure;
using Domain.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<OperationDetail> AddProductAsync(int categoryId, Product product);       
        Task<OperationDetail> AddSubcategoryAsync(int categoryId, Category category);
    }
}
