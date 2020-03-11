using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Service;
using Business.Service.FileService;
using Business.Service.Interfaces;
using Domain.EF_Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace IStore_WEB_.Controllers
{
    public class AdminController : Controller
    {
        private readonly GroupCharacteristicService _groupCharacteristicService;
        private readonly ImageFileService _fileService;
        private readonly BrandService _brandService;
        private readonly CategoryService _categoryService;
        private readonly ProductService _productService;
        private readonly ImageService _imageService;
        public AdminController(GroupCharacteristicService groupCharacteristicService, ImageFileService fileService, 
            BrandService brandService, CategoryService categoryService, ProductService productService, ImageService imageService)
        {
            _groupCharacteristicService = groupCharacteristicService;
            _fileService = fileService;
            _brandService = brandService;
            _categoryService = categoryService;
            _productService = productService;
            _imageService = imageService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetCharacteristic(int id)
        {
            var res = await _groupCharacteristicService
                .FindByConditionAsync(x => x.ProductId == 1);

            return PartialView("ProductCharacteristicPartialView", res);
        }

        [HttpPost]
        public async Task GetCharacteristicAsync(string parameters)
        {
            await _groupCharacteristicService.SaveGroupAsync((IEnumerable<GroupCharacteristic>)JsonConvert
                .DeserializeObject<List<GroupCharacteristic>>(parameters));            
        }

        public async Task<IActionResult> GetImage()
        {
            return PartialView("ImagePartialView");
        }


        [HttpPost]
        public async Task AddFile(IFormFileCollection uploads)
        {
            await _fileService.Save(uploads);
        }

        public async Task<IActionResult> AddProduct()
        {
            var categories = await _categoryService.GetAllAsync();
            var brands= await _brandService.GetAllAsync();
            ViewBag.Categories = categories.Select(x => x.Title);
            ViewBag.Brands = brands.Select(x => x.Name);
            return View();
        }

        [HttpPost]
        public async Task SaveProduct(IFormCollection formCode) 
        {
            var file = formCode.Files[0];
            
            var product = JsonConvert.DeserializeObject<Product>((formCode).ToList()[0].Value);

            product.PreviewImage = await _fileService.Save(file);


            //var viewProduct = JsonConvert.DeserializeObject<Product>(parameters);

            //var category = (await _categoryService.FindByConditionAsync(x=>x.Title== viewProduct.Category.Title)).FirstOrDefault();

            //if (category != null)           
            //    viewProduct.Category = category;            
            //else            
            //    await _categoryService.CreateAsync(viewProduct.Category);

            //var brand = (await _brandService.FindByConditionAsync(x => x.Name == viewProduct.Brand.Name)).FirstOrDefault();

            //if (brand != null)
            //    viewProduct.Brand = brand;
            //else
            //    await _brandService.CreateAsync(viewProduct.Brand);

            //viewProduct.PreviewImage =  await _fileService.Save(viewProduct.PreviewImage);

            //foreach(var item in viewProduct.Images)
            //    item.FilePath = await _fileService.Save(item.FilePath);

            ////group

            //await _productService.CreateAsync(viewProduct);
        }
    }
}