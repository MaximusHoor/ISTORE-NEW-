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
    public interface IPackageRepository : IRepository<Package>
    {
        Task<IEnumerable<Package>> FindAllPackagesAsync();
        Task<IEnumerable<Package>> FindPackageByConditionAsync(Expression<Func<Package, bool>> predicate);
        OperationDetail CreatePackage(Package package);
        OperationDetail UpdatePackage(Package package);
        OperationDetail DeletePackage(Package package);
    }
}
