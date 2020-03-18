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
        public IActionResult ShoppingCartPartial(string parameters)
        {
            if (parameters != "[]")
                return PartialView(JsonConvert.DeserializeObject<List<ProductViewModel>>(parameters));
            return null;
        }
        public IActionResult ShoppingCartProductsPartial(string parameters)
        {
            if (parameters != null)
                return PartialView(JsonConvert.DeserializeObject<List<ProductViewModel>>(parameters));
            return null;
        }
        //public async Task<IActionResult> ShoppingCartPartial(int parameters)
        //{
        //    var order = (await _orderService.FindByConditionAsync(x => x.Id == parameters)).LastOrDefault();
        //    var productViewList = new List<ProductViewModel>();
        //    foreach (var item in order.Products)
        //    {
        //        var prod = new ProductViewModel();
        //        prod.Id = item.Product.Id;
        //        prod.Model = item.Product.Model;
        //        prod.PreviewImage = item.Product.PreviewImage;
        //        prod.Rating = item.Product.Rating;
        //        prod.RetailPrice = item.Product.RetailPrice;
        //        prod.Series = item.Product.Series;
        //        prod.Title = item.Product.Title;
        //        prod.Type = item.Product.Type;
        //        prod.VendorCode = item.Product.VendorCode;
        //        prod.WarrantyMonth = item.Product.WarrantyMonth;
        //        prod.Count = item.Count;
        //        productViewList.Add(prod);
        //    }
        //    return PartialView(productViewList);
        //}
    }
}