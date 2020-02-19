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
    public class ImageRepository : BaseRepository<Image>, IImageRepository
    {
        public ImageRepository(StoreContext context) : base(context)
        {

        }
        public OperationDetail CreateImage(Image image)
        {
            return Create(image);
        }

        public OperationDetail DeleteImage(Image image)
        {
            return Delete(image);
        }

        public async Task<IEnumerable<Image>> FindAllImagesAsync()
        {
            return await FindAll().ToListAsync();
        }

        public async Task<IEnumerable<Image>> FindImageByConditionAsync(Expression<Func<Image, bool>> predicate)
        {
            return await FindByCondition(predicate).ToListAsync();
        }

        public OperationDetail UpdateImage(Image image)
        {
            return Update(image);
        }
    }
}
