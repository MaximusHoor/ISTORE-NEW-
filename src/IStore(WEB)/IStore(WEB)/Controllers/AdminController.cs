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

        public AdminController(GroupCharacteristicService groupCharacteristicService, ImageFileService fileService)
        {
            _groupCharacteristicService = groupCharacteristicService;
            _fileService = fileService;
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
    }
}