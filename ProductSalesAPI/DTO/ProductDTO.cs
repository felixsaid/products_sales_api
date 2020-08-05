using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductSalesAPI.DTO
{
    public class ProductDTO
    {

        public ProductDTO()
        {

        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double? ProductPrice { get; set; }
        public int? CategoryId { get; set; }
        public int? QuantityInStock { get; set; }
        public int? RefillLevel { get; set; }
        public DateTime? DateCreated { get; set; }

        public CategoryDTO Category { get; set; }
        public UserDTO User { get; set; }
    }
}
