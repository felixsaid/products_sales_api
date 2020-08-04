using System;
using System.Collections.Generic;

namespace ProductSalesAPI
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public int? ProductId { get; set; }
        public DateTime? TimeCreated { get; set; }
        public string OrderStatus { get; set; }
        public int? UserId { get; set; }
        public DateTime? TimeUpdated { get; set; }

        public virtual User User { get; set; }
    }
}
