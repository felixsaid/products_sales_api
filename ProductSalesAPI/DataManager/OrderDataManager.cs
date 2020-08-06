using ProductSalesAPI.DTO;
using ProductSalesAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductSalesAPI.DataManager
{
    public class OrderDataManager : IOrderRepository
    {
        private readonly ProductAPIDbContext _dbContext;

        public OrderDataManager(ProductAPIDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<OrderDTO> GetAllOrders()
        {
            var orders = (from o in _dbContext.Order
                          select new OrderDTO()
                          {
                              OrderId = o.OrderId,
                              OrderStatus = o.OrderStatus,
                              TimeCreated = o.TimeCreated,
                              TimeUpdated = o.TimeUpdated,
                              ProductId = o.ProductId,
                              UserId = o.UserId,
                              Product = new ProductOrderDTO()
                              {
                                  ProductName = o.Product.ProductName,
                                  ProductPrice = o.Product.ProductPrice,
                                  QuantityInStock = o.Product.QuantityInStock,
                                  RefillLevel = o.Product.RefillLevel,
                              }
                          }).ToList();

            return orders;
        }

        public Order AddOrder(Order orderItem)
        {
            _dbContext.Add(orderItem);
            _dbContext.SaveChanges();

            return orderItem;
        }


        public OrderDTO GetOrderById(int id)
        {
            throw new NotImplementedException();
        }

        public List<OrderDTO> SearchOrderByProduct(string productName)
        {
            throw new NotImplementedException();
        }
    }
}
