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

        public async Task<OperationDetail> CreateAsync(Package entity)
        {
            var res = await _unitOfWork.PackageRepository.CreateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return res;
        }

        public async Task<IReadOnlyCollection<Package>> FindByConditionAsync(Expression<Func<Package, bool>> predicat)
        {
            return await _unitOfWork.PackageRepository.FindByConditionAsync(predicat);
        }

        public async Task<IReadOnlyCollection<Package>> GetAllAsync()
        {
            return await _unitOfWork.PackageRepository.GetAllAsync();
        }
    }
}
