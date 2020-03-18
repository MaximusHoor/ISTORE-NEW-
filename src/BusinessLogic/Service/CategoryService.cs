using Business.Service.FileService;
using DataAccess.UnitOfWork;
using Domain.EF_Models;
using Domain.Infrastructure;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Business.Service
{
    public class CategoryService 
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ImageService _imageService;
        private readonly ImageFileService _fileService;

        public CategoryService(IUnitOfWork unitOfWork, ImageService imageService, ImageFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _imageService = imageService;
            _fileService = fileService;
        }

        public async Task<OperationDetail> CreateAsync(Category entity)
        {
            var res = await _unitOfWork.CategoryRepository.CreateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return res;
        }

        public async Task<IReadOnlyCollection<Category>> FindByConditionAsync(Expression<Func<Category, bool>> predicat)
        {
            return await _unitOfWork.CategoryRepository.FindByConditionAsync(predicat);
        }

       
        public async Task<IReadOnlyCollection<Category>> GetAllAsync()
        {
            return await _unitOfWork.CategoryRepository.GetAllAsync();
        }

        public async Task<OperationDetail> CreateAsync(IFormCollection formCode)
        {
            Category category = null;

            if (formCode.Files.Count < 1)
            {
                category = new Category()
                {
                    Title = formCode.ToList()[1].Value,
                    PreviewImage = null,
                };
            }
            else
            {
                category = new Category()
                {
                    Title = formCode.ToList()[0].Value,
                    PreviewImage = await _fileService.Save(await _imageService.ImageResizeAsync(formCode.Files[0], ".png", 20000, 300, 300)),
                };
            }

            await this.CreateAsync(category);

            return new OperationDetail();
        }

    }
}
