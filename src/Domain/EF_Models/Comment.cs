using System;
using System.Collections.Generic;

namespace Domain.EF_Models
{
    public class Comment
    {
        public Comment()
        {
            Answers = new List<Comment>();
            Likes = new List<Like>();
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public int? ParentId { get; set; }  
        public Comment Parent { get; set; }   
        public ICollection<Comment> Answers { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int LikesTotal { get; set; }
        public int DislikesTotal { get; set; }
        public int Raiting { get; set; }
        public bool IsRemoved { get; set; }
        public IEnumerable<Like> Likes { get; set; }

    }
}