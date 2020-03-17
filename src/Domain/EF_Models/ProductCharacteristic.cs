using System.Collections.Generic;

namespace Domain.EF_Models
{
    public class ProductCharacteristic
    {
        public ProductCharacteristic()
        {
            Characteristics = new List<Characteristic>();
        }

        public int Id { get; set; }
        public string Descriptions { get; set; }
        public ICollection<Characteristic> Characteristics { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}