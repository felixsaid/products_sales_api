using ProductSalesAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductSalesAPI.DataManager
{
    public class ProductDataManager : IProductRepository
    {
        public List<Product> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Product AddProduct(Product productItem)
        {
            throw new NotImplementedException();
        }

        public string DeteleteProduct(int id)
        {
            throw new NotImplementedException();
        }


        public Product UpdateProduct(int id, Product productItem)
        {
            throw new NotImplementedException();
        }
    }
}
