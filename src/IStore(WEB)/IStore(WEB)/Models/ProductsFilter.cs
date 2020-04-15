using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IStore_WEB_.Models
{
    public class ProductsFilter
    {
        public ProductsFilter()
        {
            CategoriesTitle = new List<string>();
            BrandsTitle = new List<string>();
        }
        public int PriceFrom { get; set; }
        public int PriceTo { get; set; }
        public ICollection<string> CategoriesTitle { get; set; }
        public ICollection<string> BrandsTitle { get; set; }
        public string Color { get; set; }
    }
}
