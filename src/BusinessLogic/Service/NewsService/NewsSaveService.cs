using Business.Service.FileService;
using DataAccess.UnitOfWork;
using Domain.EF_Models;
using Domain.Infrastructure;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.NewsService
{
    public class NewsSaveService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ImageFileService _fileService;
        private readonly ImageService _imageService;
        public NewsSaveService(IUnitOfWork unitOfWork, ImageFileService fileService, ImageService imageService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
            _imageService = imageService;
        }
        public async Task<OperationDetail> CreateAsync(News news)
        {
            var res = await _unitOfWork.NewsRepository.CreateAsync(news);
            await _unitOfWork.SaveChangesAsync();
            return res;
        }

        public async Task<OperationDetail> CreateAsync(IFormCollection form)
        {
            News news = null;
            
                if (form.Files.Count <= 1)
                    news = JsonConvert.DeserializeObject<News>((form).ToList()[0].Value);
                else
                    news = JsonConvert.DeserializeObject<News>((form).ToList()[1].Value);
            
            news.PhotoPath = await _fileService.Save(await _imageService.ImageResizeAsync(form.Files[0], ".png", 20000, 300, 300));

            var res = await _unitOfWork.NewsRepository.CreateAsync(news);
            await _unitOfWork.SaveChangesAsync();
            return res;
        }

        public async Task<IReadOnlyCollection<News>> GetAllAsync()
        {
            return await _unitOfWork.NewsRepository.GetAllAsync();
        }

        public async Task<News> GetByIdAsync(int id)
        {
            return await _unitOfWork.NewsRepository.GetByIdAsync(id);
        }
    }
}
