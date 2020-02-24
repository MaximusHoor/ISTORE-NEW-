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
            var res = _unitOfWork.ImageRepository.Create(image);
            await _unitOfWork.SaveChangesAsync();
            return res;
        }

        public async Task<OperationDetail> DeleteImageAsync(Image image)
        {
            var res = _unitOfWork.ImageRepository.DeleteImage(image);
            await _unitOfWork.SaveChangesAsync().ConfigureAwait(false);
            return res;
        }

        public async Task<OperationDetail> UpdateImageAsync(Image image)
        {
            var res = _unitOfWork.ImageRepository.UpdateImage(image);
            await _unitOfWork.SaveChangesAsync();
            return res;
        }

        public async Task<IEnumerable<Image>> GetImageAsync(Expression<Func<Image, bool>> predicate)
        {
            var images = await _unitOfWork.ImageRepository.FindImageByConditionAsync(predicate);
            return images;
        }

        public async Task<IEnumerable<Image>> GetAllImagesAsync()
        {
            return await _unitOfWork.ImageRepository.FindAllImagesAsync();
        }
    }
}
