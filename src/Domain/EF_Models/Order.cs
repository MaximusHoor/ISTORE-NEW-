using System;
using System.Collections.Generic;

namespace Domain.EF_Models
{
    public class Order
    {
        public Order()
        {
            Products = new List<OrderDetails>();
        }

        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public double Total { get; set; }
        public ICollection<OrderDetails> Products { get; set; }
        public string? UserId { get; set; }
        public User User { get; set; }
        public int? DeliveryId { get; set; }
        public Delivery Delivery { get; set; }
        public string DeliveryStatus { get; set; }
        public string PaymentStatus { get; set; }
    }
}