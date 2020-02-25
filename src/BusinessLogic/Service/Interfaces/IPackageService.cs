using Domain.EF_Models;
using Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.Interfaces
{
    public interface IPackageService
    {
        Task<OperationDetail> AddPackageAsync(Package package);
        Task<IEnumerable<Package>> GetPackageAsync(Expression<Func<Package, bool>> predicate);
        Task<IEnumerable<Package>> GetAllPackagesAsync();
    }
}
