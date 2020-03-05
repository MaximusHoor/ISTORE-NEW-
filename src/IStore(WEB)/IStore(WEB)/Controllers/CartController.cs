using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Business.Service;
using DataAccess.UnitOfWork;
using Domain.EF_Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace IStore_WEB_.Controllers
{
    public class CartController : Controller
    {
        private readonly OrderService _orderService;
        private readonly IUnitOfWork _unitOfWork;
        public CartController(OrderService orderService, IUnitOfWork unitOfWork)
        {
            _orderService = orderService;
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> ShoppingCart()
        {
            var currentUser = 1;
            var order = (await _orderService.FindByConditionAsync(x => x.UserId == currentUser && x.PaymentStatus != "for paid")).LastOrDefault();
            //foreach (var item in order.Products)
            //{
            //var prod = JsonConvert.SerializeObject(order.Products.FirstOrDefault(), Formatting.Indented, new JsonSerializerSettings
            //{
            //    PreserveReferencesHandling = PreserveReferencesHandling.Objects
            //});
            //var prod = order.Products.FirstOrDefault();
            //    Response.Cookies.Append("IStoreProduct", $"{prod.Id},{prod.OrderId},{prod.ProductId}");
            //}
            var prod = order.Products.ToArray();
            var str = JsonConvert.SerializeObject(prod, Formatting.Indented, new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects
            });
            //Response.Cookies.Append("IStoreProduct", "hello");
            var we = WebUtility.HtmlEncode(str);
            var ws = WebUtility.HtmlDecode(str);

            //ViewBag.Products = WebUtility.HtmlEncode(str);
            return View();
        }
        public async Task<IActionResult> Checkout()
        {
            var currentUser = 1;
            var order = (await _orderService.FindByConditionAsync(x => x.UserId == currentUser && x.PaymentStatus != "for paid")).LastOrDefault();
            return View();
        }
        public async Task AddProductToCart(int id)
        {
            var currentUser = 1;
            var order = (await _orderService.FindByConditionAsync(x => x.UserId == currentUser && x.PaymentStatus != "for paid")).LastOrDefault();
            if (order == null)
            {
                order = new Order() { Date = DateTime.Now, UserId = currentUser };
                await _orderService.CreateAsync(order);
            }
            order.Products.Add(new OrderDetails() { OrderId = order.Id, ProductId = 1, Count = 1 });
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task UpdateProducts(string parameters)
        {
            var currentUser = 1;
            var order = (await _orderService.FindByConditionAsync(x => x.UserId == currentUser && x.PaymentStatus != "for paid")).LastOrDefault();
            order.Products = JsonConvert.DeserializeObject<ICollection<OrderDetails>>(parameters);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<IActionResult> ShoppingCartPartial()
        {
            var currentUser = 1;
            var order = (await _orderService.FindByConditionAsync(x => x.UserId == currentUser && x.PaymentStatus != "for paid")).LastOrDefault();
            return PartialView(order);
        }
        public IActionResult ShoppingCartProductsPartial(string parameters)
        {
            if(parameters!=null)
            return PartialView(JsonConvert.DeserializeObject<ICollection<OrderDetails>>(parameters));
            return null;
        }
    }
}