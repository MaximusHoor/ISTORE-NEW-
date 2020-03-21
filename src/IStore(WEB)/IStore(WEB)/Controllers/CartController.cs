using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Business.Service;
using DataAccess.UnitOfWork;
using Domain.EF_Models;
using IStore_WEB_.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace IStore_WEB_.Controllers
{
    public class CartController : Controller
    {
        private readonly OrderService _orderService;
        public CartController(OrderService orderService, IUnitOfWork unitOfWork)
        {
            _orderService = orderService;
        }
        public async Task<IActionResult> ShoppingCart()
        {
            return View();
        }
        public async Task<IActionResult> Checkout()
        {
            return View();
        }
        public async Task<IActionResult> CheckoutProductPartial(string parameters)
        {
            if (parameters != "[]")
                return PartialView(JsonConvert.DeserializeObject<List<ProductViewModel>>(parameters));
            return null;
        }
        public async Task<IActionResult> ShoppingCartPartial(string parameters)
        {
            if (parameters != "[]")
                return PartialView(JsonConvert.DeserializeObject<List<ProductViewModel>>(parameters));
            return null;
        }
        public async Task<IActionResult> ShoppingCartProductsPartial(string parameters)
        {
            if (parameters != null)
                return PartialView(JsonConvert.DeserializeObject<List<ProductViewModel>>(parameters));
            return null;
        }
    }
}