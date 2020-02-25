using Business.Service.Interfaces;
using DataAccess.UnitOfWork;
using Domain.EF_Models;
using Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service
{
    public class PackageService : IPackageService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PackageService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;
        public async Task<OperationDetail> AddPackageAsync(Package package)
        {
            var res = _unitOfWork.PackageRepository.CreatePackage(package);
            await _unitOfWork.SaveChangesAsync();
            return res;
        }

        public async Task<OperationDetail> DeletePackageAsync(Package package)
        {
            var res = _unitOfWork.PackageRepository.DeletePackage(package);
            await _unitOfWork.SaveChangesAsync().ConfigureAwait(false);
            return res;
        }

        public async Task<IEnumerable<Package>> GetAllPackagesAsync()
        {
            return await _unitOfWork.PackageRepository.FindAllPackagesAsync();
        }

        public async Task<IEnumerable<Package>> GetPackageAsync(Expression<Func<Package, bool>> predicate)
        {
            return await _unitOfWork.PackageRepository.FindPackageByConditionAsync(predicate);
        }

        public async Task<OperationDetail> UpdatePackageAsync(Package package)
        {
            var res = _unitOfWork.PackageRepository.UpdatePackage(package);
            await _unitOfWork.SaveChangesAsync();
            return res;
        }
    }
}
