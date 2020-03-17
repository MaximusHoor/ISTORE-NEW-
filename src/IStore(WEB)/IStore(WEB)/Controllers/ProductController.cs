using Business.Service;
using Domain.EF_Models;
using IStore_WEB_.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace IStore_WEB_.Controllers
{
    public class ProductController:Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly ProductService _productservice;
        private readonly ProductCharacteristicService _productCharacteristicService;
        private readonly CommentService _commentService;
        public ProductController(ILogger<ProductController> logger, ProductService productservice, ProductCharacteristicService productCharacteristicService,CommentService commentService)
        {
            _logger = logger;
            _productservice = productservice;
            _commentService = commentService;
            this._productCharacteristicService = productCharacteristicService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _productservice.GetSortByRatingAsync(24);
            return View(result);
        }

        public async Task<IActionResult> ProductCharacteristicPart(int id)
        {
            var res = await _productCharacteristicService.FindByConditionAsync(x=>x.ProductId == id);
            return View(res.FirstOrDefault());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> ProductPartial(Product product)
        {
            return View(product);
        }

        public async Task<IActionResult> GetProductDetails(Product product)
        {
            var res = await _productservice.GetByIdsync(1);


            return PartialView("ProductDetails", res);
        }
        public async Task<IActionResult> Product(int id)
        {
            var res = await _productservice.GetByIdsync(1);

            return View("Product", res);
        }
        public async Task<IActionResult> GetCommentsPartial(int id)
        {
           
            var comments = await _commentService.GetCommentsByProductAsync(id);
           
           // ViewBag.Likes = await _commentService.GetUserCommentsLikes(1, id);
          //  ViewBag.Dislikes = await _commentService.GetUserCommentsDislikes(1, id);

            return PartialView(comments);
        }
        public ActionResult GetInputCommentPartial()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task AddLikes(string localStorageResult)
        {
            var res= JsonConvert.DeserializeObject<List<Like>>(localStorageResult);
         //   await _likeService.ManageLikesAsync(res);
        }
        [HttpPost]
        public async Task AddComment(string comment)
        {
            var res = JsonConvert.DeserializeObject<Comment>(comment);
            res.Date = DateTime.Now;
            await _commentService.CreateCommentAsync(res);

        }
        

    }




}
