using Domain.EF_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IStore_WEB_.Models
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public ICollection<Comment> Answers { get; set; }
        public int? UserId { get; set; }
        public int ProductId { get; set; }
        public int LikesTotal { get; set; }
        public int DislikeTotal { get; set; }
        public int Raiting { get; set; }
        public ICollection<int> CommentsLikes { get; set; }
        public bool UserDislikeLeft { get; set; }
    }
}
