using DataAccess.UnitOfWork;
using Domain.EF_Models;
using Domain.Infrastructure;
using Domain.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
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

        public OperationDetail AddImage(Image image)
        {
            var res = _unitOfWork.ImageRepository.Create(image);
            _unitOfWork.SaveChangesAsync();
            return res;
        }

        public OperationDetail DeleteImage(Image image)
        {
            var res = _unitOfWork.ImageRepository.DeleteImage(image);
            _unitOfWork.SaveChangesAsync();
            return res;
        }

        public OperationDetail UpdateImage(Image image)
        {
            var res = _unitOfWork.ImageRepository.UpdateImage(image);
            _unitOfWork.SaveChangesAsync();
            return res;
        }

        public async Task<IEnumerable<Image>> GetImage(Expression<Func<Image, bool>> predicate)
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
