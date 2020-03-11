using Business.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IStore_WEB_.Controllers
{
    public class ProductController:Controller
    {
        private readonly ProductCharacteristicService _productCharacteristicService;

        public ProductController(ProductCharacteristicService productCharacteristicService)
        {
            this._productCharacteristicService = productCharacteristicService;
        }

        public async Task<IActionResult> ProductCharacteristicPart(int id)
        {
            var res = await _productCharacteristicService.FindByConditionAsync(x=>x.ProductId == id);
            return View(res.FirstOrDefault());
        }

        public IActionResult Index()
        {
            return View();
        }
    }




}
