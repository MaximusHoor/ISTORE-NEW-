using DataAccess.UnitOfWork;
using Domain.EF_Models;
using Domain.Infrastructure;
using Microsoft.AspNetCore.Http;
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

        
        public async Task<System.Drawing.Image> ImageResizeAsync(IFormFile file, string ext, int maxWeight, int maxWidth, int maxHeight)
        {
            System.Drawing.Bitmap newImage = null;

            if (file.FileName.Substring(file.FileName.IndexOf('.')) != ext)
            {
                return null;               
            }

            if (file.Length > maxWeight)
            {
                return null;                
            }

            using (var image = new System.Drawing.Bitmap(System.Drawing.Image.FromStream(file.OpenReadStream(), true, true)))
            {
                    if (image.Width == maxWidth && image.Height == maxHeight)
                    {
                        return new System.Drawing.Bitmap(image);
                    }
                    else
                    {
                        newImage = new System.Drawing.Bitmap(maxWidth, maxHeight);
                        using (var g = System.Drawing.Graphics.FromImage(newImage))
                        {
                            g.DrawImage(image, 0, 0, maxWidth, maxHeight);
                            return newImage;
                        }
                    }
            }           
        }        
    }
}
