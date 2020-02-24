using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Infrastructure
{
    public class OperationDetailDTO
    {
        public string Message { get; set; }
        public Exception Exception { get; set; }
        public bool IsError { get; set; }
    }
}
