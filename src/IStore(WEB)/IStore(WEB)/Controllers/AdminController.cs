using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Service;
using Business.Service.Interfaces;
using Domain.EF_Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace IStore_WEB_.Controllers
{
    public class AdminController : Controller
    {
        private readonly ProductCharacteristicService _productCharacteristicService;

        public AdminController(ProductCharacteristicService productCharacteristicService)
        {
            _productCharacteristicService = productCharacteristicService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetCharacteristic(int id)
        {
            var res = await _productCharacteristicService
                .FindByConditionAsync(x => x.ProductId == 1);

            return PartialView("ProductCharacteristicPartialView", res);
        }

        [HttpPost]
        public async Task GetCharacteristicAsync(string parameters)
        {
            await _productCharacteristicService.SaveGroupAsync((IEnumerable<ProductCharacteristic>)JsonConvert
                .DeserializeObject<List<ProductCharacteristic>>(parameters));            
        }

        
    }
}