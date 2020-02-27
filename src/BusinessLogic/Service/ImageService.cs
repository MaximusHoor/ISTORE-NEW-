using DataAccess.UnitOfWork;
using Domain.EF_Models;
using Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Business.Service
{
    public class ImageService 
    {
        private readonly IUnitOfWork _unitOfWork;

        public ImageService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationDetail> CreateAsync(Image entity)
        {
            var res = await _unitOfWork.ImageRepository.CreateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return res;
        }

        public async Task<IReadOnlyCollection<Image>> FindByConditionAsync(Expression<Func<Image, bool>> predicat)
        {
            return await _unitOfWork.ImageRepository.FindByConditionAsync(predicat);
        }
    

        public async Task<IReadOnlyCollection<Image>> GetAllAsync()
        {
            return await _unitOfWork.ImageRepository.GetAllAsync();
        }
    }
}
