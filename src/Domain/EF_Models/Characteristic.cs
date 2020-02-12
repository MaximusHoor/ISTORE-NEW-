using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.EF_Models
{
    class Characteristic
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }
        public int GroupCharacteristicId { get; set; }
        public GroupCharacteristic GroupCharacteristic { get; set; }
    }
}
