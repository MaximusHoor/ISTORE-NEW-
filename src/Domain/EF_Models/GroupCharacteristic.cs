using System.Collections.Generic;

namespace Domain.EF_Models
{
    public class GroupCharacteristic
    {
        public GroupCharacteristic()
        {
            Characteristics = new List<Characteristic>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<Characteristic> Characteristics { get; set; }
        public int? ProductId { get; set; }
        public Product Product { get; set; }
    }
}