using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductSalesAPI.DTO
{
    public class CategoryDTO
    {

        public CategoryDTO()
        {

        }

        public string CategoryName { get; set; }
        public bool? CategoryActive { get; set; }
    }
}
