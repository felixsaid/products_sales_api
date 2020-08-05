using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductSalesAPI.DTO;
using ProductSalesAPI.Repository;
using ProductSalesAPI.Services;

namespace ProductSalesAPI.Controllers
{
    [Route("v1/api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private ILogger _logger;
        readonly IProductRepository _productRepository;

        public ProductController(ILogger<ProductController> logger, IProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = _productRepository.GetAllProducts();
            ProductResponse response = new ProductResponse();

            response.error = false;
            response.message = "success";
            response.data = products;
            
            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var _product = _productRepository.GetProductById(id);

            ProductResponse response = new ProductResponse();

            response.error = false;
            response.message = "success";
            response.data = _product;
            

           if(_product == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpPost]
        public IActionResult AddNewProduct([FromBody] Product product)
        {
            _productRepository.AddProduct(product);

            ProductCreateDTO productDTO = new ProductCreateDTO();
            productDTO.ProductId = product.ProductId;
            productDTO.ProductName = product.ProductName;
            productDTO.ProductPrice = product.ProductPrice;
            productDTO.DateCreated = product.DateCreated;

            ProductResponse response = new ProductResponse();

            response.error = false;
            response.message = "success";
            response.data = productDTO;

            return Ok(response);
        }
    }
}
