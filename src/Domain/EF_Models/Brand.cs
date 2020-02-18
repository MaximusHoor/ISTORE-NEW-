using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.EF_Models
{
  public  class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
    }
}
