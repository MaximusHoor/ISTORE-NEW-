using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Service;
using Business.Service.FileService;
using Business.Service.Interfaces;
using Domain.EF_Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace IStore_WEB_.Controllers
{
    //[Authorize(Roles = "admin")]
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

        //[AllowAnonymous]
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

            var category = (await _categoryService.FindByConditionAsync(x => x.Title == product.Category.Title)).FirstOrDefault();

            if (category != null)
                product.Category = category;
            else
                await _categoryService.CreateAsync(product.Category);

            var brand = (await _brandService.FindByConditionAsync(x => x.Name == product.Brand.Name)).FirstOrDefault();

            if (brand != null)
                product.Brand = brand;
            else
                await _brandService.CreateAsync(product.Brand);

            //group

            await _productService.CreateAsync(product);
        }

        public IActionResult AddCategory()
        {
            return PartialView();
        }

        [HttpPost]   //ajax - запрос
        public async Task<IActionResult> SaveCategory(IFormCollection formCode)
        {
            

            var category = new Category()
            {
                Title = formCode.ToList()[0].Value,
                PreviewImage = await _fileService.Save(await _imageService.ImageResizeAsync(formCode.Files[0], ".png", 20000, 300, 300)),
            };

            var res = await _categoryService.CreateAsync(category);

            var result = (await _categoryService.GetAllAsync()).Select(x=>x.Title).ToList();
            
            return Json(result);
        }
    }
}