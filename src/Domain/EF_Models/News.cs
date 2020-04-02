using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.EF_Models
{
    public class News
    {
        public News()
        {
            SentOut = false;
        }
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public string PhotoPath { get; set; }
        public bool SentOut { get; set; }
    }
}
