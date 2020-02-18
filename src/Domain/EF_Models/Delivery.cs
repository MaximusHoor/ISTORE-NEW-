using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.EF_Models
{
    class Delivery
    {
        public int Id { get; set; }
        public string DeliveryNote { get; set; }
        public int? DeliveryServiceId { get; set; }
        public DeliveryService DeliveryService { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }
        public string BranchDeliveryService { get; set; }
        public int? AddressId { get; set; }
        public Address AddressDelivery { get; set; }
    }
}
