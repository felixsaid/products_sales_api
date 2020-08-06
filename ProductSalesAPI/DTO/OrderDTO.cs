using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductSalesAPI.DTO
{
    public class OrderDTO
    {
        public OrderDTO() { }

        public int OrderId { get; set; }
        public int? ProductId { get; set; }
        public DateTime? TimeCreated { get; set; }
        public string OrderStatus { get; set; }
        public int? UserId { get; set; }
        public DateTime? TimeUpdated { get; set; }

        public virtual User User { get; set; }
        public virtual ProductOrderDTO Product { get; set; }
    }
}
