using Business.Service.Interfaces;
using Domain.EF_Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IStore_WEB_.Controllers
{
    public class ProductController:Controller
    {
        private readonly ICommentService _commentService;
        private readonly ILikeService _likeService;
        public ProductController(ICommentService commentService,ILikeService likeService) { 
            _commentService = commentService;
            _likeService = likeService;
        }
        public IActionResult Index()
        {
            return View();
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
