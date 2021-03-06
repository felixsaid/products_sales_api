﻿using ProductSalesAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductSalesAPI.Repository
{
    public interface IProductRepository
    {
        public List<ProductDTO> GetAllProducts();
        public ProductDTO GetProductById(int id);
        public Product AddProduct(Product productItem);
        public Product UpdateProduct(int id, Product productItem);
        public int DeleteProduct(int id);
        public List<ProductDTO> SearchProductByCategory(string categoryName);
    }
}
