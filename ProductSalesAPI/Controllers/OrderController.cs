using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductSalesAPI.DTO;
using ProductSalesAPI.Repository;
using ProductSalesAPI.Wrappers;

namespace ProductSalesAPI.Controllers
{
    [Route("v1/api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IOrderRepository _orderRepository;

        public OrderController(ILogger<OrderController> logger, IOrderRepository orderRepository)
        {
            _logger = logger;
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var orders = _orderRepository.GetAllOrders();

            if(orders.Equals(0))
            {
                return NotFound();
            }

            return Ok(new Response<List<OrderDTO>>(orders));
        }

        [HttpPost]
        public IActionResult CreateNewOrder([FromBody] Order order)
        {
            _orderRepository.AddOrder(order);

            OrderCreateDTO orderCreateDTO = new OrderCreateDTO();
            orderCreateDTO.OrderId = order.OrderId;
            orderCreateDTO.OrderStatus = order.OrderStatus;

            return Ok(new Response<OrderCreateDTO>(orderCreateDTO));
        }
    }
}
