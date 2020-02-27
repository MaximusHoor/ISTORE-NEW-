using DataAccess.Repository.Interfaces;
using Domain.Context;
using Domain.EF_Models;
using Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class BrandRepository : BaseRepository<Brand>
    {
        public BrandRepository(StoreContext context) : base(context)
        {

        }

        public override async Task<IReadOnlyCollection<Brand>> GetAllAsync()
        {
            return await this.Entities.ToListAsync().ConfigureAwait(false);
        }

        public override async Task<IReadOnlyCollection<Brand>> FindByConditionAsync(Expression<Func<Brand, bool>> predicat)
        {
            return await this.Entities.Where(predicat).ToListAsync().ConfigureAwait(false);
        }

        
    }
}
