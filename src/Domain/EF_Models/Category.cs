using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.EF_Models
{
    public class Category
    {
        public Category()
        {
            Products = new List<Product>();
            Subcategories = new List<Category>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string PreviewImage { get; set; }
        public int? ParentCategoryId { get; set; }
        [ForeignKey("ParentCategoryId")]
        public Category ParentCategory { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<Category> Subcategories { get; set; }
    }
}