﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.EF_Models
{
    class Address
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public string ApartmentNumber { get; set; }
    }
}