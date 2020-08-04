using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductSalesAPI.Repository
{
    public interface IProductRepository
    {
        public List<Product> GetAllProducts();
        public Product AddProduct(Product productItem);
        public Product UpdateProduct(int id, Product productItem);
        public string DeteleteProduct(int id);
    }
}
