using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Service;
using Microsoft.AspNetCore.Mvc;

namespace IStore_WEB_.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryService _categoryService;

        public CategoryController(CategoryService categoryService)
        {
            this._categoryService = categoryService;
        }
        public async Task<IActionResult> ShowCategoryPartial()
        {
            var res = await _categoryService.GetAllAsync();

            return View(res.ToList());
        }

        public async Task<IActionResult> GetCategoryJson()
        {
            try
            {
                var categoryCollection = await _categoryService.GetAllAsync();
                var res = Json(categoryCollection);
                return res;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}