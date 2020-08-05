using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ProductSalesAPI.Services
{

    public class ProductResponse
    {
        
        public bool error { get; set; }
        public string message { get; set; }
        public object data { get; set; }

    }
}
