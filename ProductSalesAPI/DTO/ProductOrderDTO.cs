using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductSalesAPI.DTO
{
    public class ProductOrderDTO
    {
        public ProductOrderDTO() { }

        public string ProductName { get; set; }
        public double? ProductPrice { get; set; }
        public int? QuantityInStock { get; set; }
        public int? RefillLevel { get; set; }
    }
}
