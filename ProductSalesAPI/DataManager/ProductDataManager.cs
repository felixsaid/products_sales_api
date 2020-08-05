using ProductSalesAPI.DTO;
using ProductSalesAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductSalesAPI.DataManager
{
    public class ProductDataManager : IProductRepository
    {

        readonly ProductAPIDbContext _dbContext;

        public ProductDataManager(ProductAPIDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<ProductDTO> GetAllProducts()
        {
            var _products = (from b in _dbContext.Product
                             select new ProductDTO()
                             {
                                 ProductId = b.ProductId,
                                 ProductName = b.ProductName,
                                 ProductPrice = b.ProductPrice,
                                 QuantityInStock = b.QuantityInStock,
                                 RefillLevel = b.RefillLevel,
                                 CategoryId = b.CategoryId,
                                 DateCreated = b.DateCreated,
                                 Category = new CategoryDTO()
                                 {
                                     CategoryName = b.Category.CategoryName,
                                     CategoryActive = b.Category.CategoryActive
                                 },
                                 User = new UserDTO()
                                 {
                                     UserId = b.User.UserId,
                                     UserName = b.User.UserName,
                                     UserEmail = b.User.UserEmail
                                 }
                             }).ToList();
          
            return _products;
        }

        public ProductDTO GetProductById(int id)
        {
            var products = (from b in _dbContext.Product
                            select new ProductDTO()
                            {
                                ProductId = b.ProductId,
                                ProductName = b.ProductName,
                                ProductPrice = b.ProductPrice,
                                QuantityInStock = b.QuantityInStock,
                                RefillLevel = b.RefillLevel,
                                CategoryId = b.CategoryId,
                                DateCreated = b.DateCreated,
                                Category = new CategoryDTO()
                                {
                                    CategoryName = b.Category.CategoryName,
                                    CategoryActive = b.Category.CategoryActive
                                },
                                User = new UserDTO()
                                {
                                    UserId = b.User.UserId,
                                    UserName = b.User.UserName,
                                    UserEmail = b.User.UserEmail
                                }
                            }).FirstOrDefault(a => a.ProductId == id);

            return products;
        }

        public Product AddProduct(Product productItem)
        {
            _dbContext.Add(productItem);
            _dbContext.SaveChanges();

            return productItem;
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