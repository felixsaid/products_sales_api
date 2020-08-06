using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductSalesAPI.DTO
{
    public class OrderCreateDTO
    {
        public OrderCreateDTO() { }

        public int OrderId { get; set; }
        public string OrderStatus { get; set; }
    }
}
