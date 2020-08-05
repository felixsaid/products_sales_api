using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductSalesAPI.DTO
{
    public class ProductCreateDTO
    {
        public ProductCreateDTO()
        {

        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double? ProductPrice { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
