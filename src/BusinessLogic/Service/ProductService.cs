using Business.Service.FileService;
using Business.Service.Interfaces;
using DataAccess.UnitOfWork;
using Domain.EF_Models;
using Domain.Infrastructure;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service
{
    public class ProductService 
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly ImageFileService _fileService;
        private readonly ImageService _imageService;
        private readonly CategoryService _categoryService;
        private readonly BrandService _brandService;


        public ProductService(IUnitOfWork unitOfWork, ImageFileService fileService, ImageService imageService,
            CategoryService categoryService, BrandService brandService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
            _imageService = imageService;
            _categoryService = categoryService;
            _brandService = brandService;
    }

        public async Task<OperationDetail> CreateAsync(Product entity)
        {
            var res = await _unitOfWork.ProductRepository.CreateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return res;
        }

        public async Task<IReadOnlyCollection<Product>> FindByConditionAsync(Expression<Func<Product, bool>> predicat)
        {
            return await _unitOfWork.ProductRepository.FindByConditionAsync(predicat);
        }
       

        public async Task<IReadOnlyCollection<Product>> GetAllAsync()
        {
            return await _unitOfWork.ProductRepository.GetAllAsync();
        }

        public async Task<Product> GetByIdsync(int id)
        {
            return await _unitOfWork.ProductRepository.GetByIdAsync(id);
        }

        public async Task<IReadOnlyCollection<Product>> GetSortByRatingAsync(int count)
        {
            return await _unitOfWork.ProductRepository.GetSortByRatingAsync(count);
        }

        public async Task<OperationDetail> CreateAsync(IFormCollection formCode)
        {
            Product product = null;

            if (formCode.Files.Count <= 1)
                product = JsonConvert.DeserializeObject<Product>((formCode).ToList()[1].Value);
            else
                product = JsonConvert.DeserializeObject<Product>((formCode).ToList()[0].Value);

            product.PreviewImage = await _fileService.Save(await _imageService.ImageResizeAsync(formCode.Files[0], ".png", 20000, 300, 300));

            for (int i = 1; i < formCode.Files.Count; i++)
            {
                var image = await _imageService.ImageResizeAsync(formCode.Files[i], ".png", 100000, 650, 650);
                product.Images.Add(new Image() { FilePath = await _fileService.Save(image), Product = product });
            }

            product.Category = (await _categoryService.FindByConditionAsync(x => x.Title == product.Category.Title)).FirstOrDefault(); ;

            product.Brand = (await _brandService.FindByConditionAsync(x => x.Name == product.Brand.Name)).FirstOrDefault(); ;

            await this.CreateAsync(product);

            return new OperationDetail();
        }
    }
}
