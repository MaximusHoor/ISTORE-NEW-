using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.EF_Models
{
    class DeliveryService
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string BranchNumber { get; set; }
        public int AddressId { get; set; }
        public Address Adddress { get; set; }
    }
}
