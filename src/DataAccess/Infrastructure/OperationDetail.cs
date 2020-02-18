using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Infrastructure
{
  public class OperationDetail
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public Exception ex { get; set; }
    }
}
