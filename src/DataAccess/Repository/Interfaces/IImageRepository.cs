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
    public interface IImageRepository : IRepository<Image>
    {
        Task<IEnumerable<Image>> FindAllImagesAsync();
        Task<IEnumerable<Image>> FindImageByConditionAsync(Expression<Func<Image, bool>> predicate);
        OperationDetail CreateImage(Image image);
        OperationDetail UpdateImage(Image image);
        OperationDetail DeleteImage(Image image);
    }
}
