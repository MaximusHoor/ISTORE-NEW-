using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.EF_Models
{
    class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PreviewImage { get; set; }
        public List<Product> Products { get; set; }
        public List<Category> Subcategories { get; set; }
    }
}
