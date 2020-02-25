using Domain.EF_Models;
using Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Business.Service
{
    public interface IImageService
    {
        Task<OperationDetail> AddImageAsync(Image image);
        Task<IEnumerable<Image>> GetImageAsync(Expression<Func<Image, bool>> predicate);
        Task<IEnumerable<Image>> GetAllImagesAsync();
    }
}