using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductSalesAPI.Wrappers
{
    public class ErrorResponse
    {
        public bool error { get; set; }
        public string message { get; set; }
        public string content { get; set; }
    }
}
