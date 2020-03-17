using System;
using System.Collections.Generic;

namespace Domain.EF_Models
{
    public class Product
    {
        public Product()
        {
            Images = new List<Image>();
            ProductCharacteristics = new List<ProductCharacteristic>();
            Comments = new List<Comment>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string VendorCode { get; set; }
        public string Description { get; set; }
        public int? BrandId { get; set; }
        public Brand Brand { get; set; }
        public double RetailPrice { get; set; }
        public string PreviewImage { get; set; }
        public ICollection<Image> Images { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int PackageId { get; set; }
        public Package Package { get; set; }
        public ICollection<ProductCharacteristic> ProductCharacteristics { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public int CountInStorage { get; set; }
        public int Rating { get; set; }
        public int WarrantyMonth { get; set; }
        public string Series { get; set; }
        public string Model { get; set; }
    }
}