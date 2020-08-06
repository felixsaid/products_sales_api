using ProductSalesAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductSalesAPI.Repository
{
    public interface IOrderRepository
    {
        public List<OrderDTO> GetAllOrders();
        public OrderDTO GetOrderById(int id);
        public Order AddOrder(Order orderItem);
        public List<OrderDTO> SearchOrderByProduct(string productName);
    }
}
