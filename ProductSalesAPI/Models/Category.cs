using System;
using System.Collections.Generic;

namespace ProductSalesAPI
{
    public partial class Category
    {
        public Category()
        {
            Product = new HashSet<Product>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool? CategoryActive { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
