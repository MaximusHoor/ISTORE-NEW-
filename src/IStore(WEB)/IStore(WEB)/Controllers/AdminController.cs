using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Service;
using Business.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IStore_WEB_.Controllers
{
    public class AdminController : Controller
    {
        private readonly GroupCharacteristicService _groupCharacteristicService;

        public AdminController(GroupCharacteristicService groupCharacteristicService)
        {
            _groupCharacteristicService = groupCharacteristicService;
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
    }
}