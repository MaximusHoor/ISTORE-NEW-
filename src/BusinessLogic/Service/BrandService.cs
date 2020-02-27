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
    public class BrandService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BrandService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationDetail> CreateAsync(Brand entity)
        {
            var res = await _unitOfWork.BrandRepository.CreateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return res;
        }

        public async Task<IReadOnlyCollection<Brand>> FindByConditionAsync(Expression<Func<Brand, bool>> predicat)
        {
            return await _unitOfWork.BrandRepository.FindByConditionAsync(predicat);
        }

        public async Task<IReadOnlyCollection<Brand>> GetAllAsync()
        {
            return await _unitOfWork.BrandRepository.GetAllAsync();
        }
    }
}
