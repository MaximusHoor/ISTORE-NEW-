using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.EF_Models
{
    class GroupCharacteristic
    {
        public GroupCharacteristic()
        {
            Characteristics = new List<Characteristic>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<Characteristic> Characteristics { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
