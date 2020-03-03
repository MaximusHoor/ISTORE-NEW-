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

        [HttpPost]
        public async Task GetCharacteristic(string parameters)
        {
            await _groupCharacteristicService.SaveAllFromAdminAsync(JsonConvert.DeserializeObject<List<GroupCharacteristic>>(parameters));            
        }

    }
}