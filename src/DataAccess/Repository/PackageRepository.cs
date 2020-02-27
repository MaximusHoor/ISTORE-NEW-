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
    public class PackageRepository : BaseRepository<Package>
    {
        public PackageRepository(StoreContext context) : base(context)
        {
        }
        public override async Task<IReadOnlyCollection<Package>> GetAllAsync()
        {
            return await this.Entities.ToListAsync().ConfigureAwait(false);
        }

        public override async Task<IReadOnlyCollection<Package>> FindByConditionAsync(Expression<Func<Package, bool>> predicat)
        {
            return await this.Entities.Where(predicat).ToListAsync().ConfigureAwait(false);
        }
    }
}
