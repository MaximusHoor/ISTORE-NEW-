using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.EF_Models
{
    class Comment
    {
        public Comment()
        {
            Answers = new List<Comment>();
        }
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public ICollection<Comment> Answers { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Like { get; set; }
        public int Dislike { get; set; }
    }
}
