using DataAccess.UnitOfWork;
using Domain.EF_Models;
using Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Business.Service
{
    public class ImageService : IImageService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ImageService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationDetail> AddImageAsync(Image image)
        {
            var res = await _unitOfWork.ImageRepository.CreateAsync(image).ConfigureAwait(false);
            await _unitOfWork.SaveChangesAsync().ConfigureAwait(false);
            return res;
        }

        public async Task<IEnumerable<Image>> GetAllImagesAsync()
        {
            return await _unitOfWork.ImageRepository.GetAllAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<Image>> GetImageAsync(Expression<Func<Image, bool>> predicate)
        {
            return await _unitOfWork.ImageRepository.FindByConditionAsync(predicate).ConfigureAwait(false);
        }
    }
}
