using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.EF_Models
{
   public class Like
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int CommentId { get; set; }
        public int ProductId { get; set; }
        public bool IsLiked { get; set; }
        public bool IsLikeRemoved { get; set; }
        public DateTime Date { get; set; }

    }
}
