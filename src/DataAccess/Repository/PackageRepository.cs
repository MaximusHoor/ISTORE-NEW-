using DataAccess.Repository.Interfaces;
using Domain.Context;
using Domain.EF_Models;
using Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class PackageRepository : BaseRepository<Package>, IPackageRepository
    {
        public PackageRepository(StoreContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Package>> FindAllPackagesAsync()
        {
            Log.Information($"{DateTime.Now} - FindAllPackagesAsync");
            return await FindAll().ToListAsync();
        }

        public async Task<IEnumerable<Package>> FindPackageByConditionAsync(Expression<Func<Package, bool>> predicate)
        {
            Log.Information($"{DateTime.Now} - FindPackageByConditionAsync");
            return await FindByCondition(predicate).ToListAsync();
        }
    }
}
