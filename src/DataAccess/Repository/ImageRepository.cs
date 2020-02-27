using DataAccess.Repository.Interfaces;
using Domain.Context;
using Domain.EF_Models;
using Domain.Infrastructure;
using Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ImageRepository : BaseRepository<Image>
    {
        public ImageRepository(StoreContext context) : base(context)
        {

        }
        public override async Task<IReadOnlyCollection<Image>> GetAllAsync()
        {
            return await this.Entities.Include(img => img.Product).ToListAsync().ConfigureAwait(false);
        }

        public override async Task<IReadOnlyCollection<Image>> FindByConditionAsync(Expression<Func<Image, bool>> predicat)
        {
            return await this.Entities.Include(img => img.Product).Where(predicat).ToListAsync().ConfigureAwait(false);
        }

       
    }
}
