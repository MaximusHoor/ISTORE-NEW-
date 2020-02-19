using System;

namespace Domain.EF_Models
{
    public class Delivery
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string DeliveryNote { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }
        public string BranchDeliveryService { get; set; }
        public int? AddressId { get; set; }
        public Address AddressDelivery { get; set; }
    }
}