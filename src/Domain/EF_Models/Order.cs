using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.EF_Models
{
    class Order
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
        public int? UserId { get; set; }
        public User User { get; set; }
        public int? DeliveryId { get; set; }
        public Delivery Delivery { get; set; }
        public string DeliveryStatus { get; set; }
        public string PaymentStatus { get; set; }
    }
}
