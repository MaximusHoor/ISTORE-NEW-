using System.Collections.Generic;

namespace Domain.EF_Models
{
    public class ProductCharacteristic
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}