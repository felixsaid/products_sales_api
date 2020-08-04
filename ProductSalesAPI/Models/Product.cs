using System;
using System.Collections.Generic;

namespace ProductSalesAPI
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double? ProductPrice { get; set; }
        public int? CategoryId { get; set; }
        public int? QuantityInStock { get; set; }
        public int? RefillLevel { get; set; }
        public int? UserId { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual Category Category { get; set; }
        public virtual User User { get; set; }
    }
}
