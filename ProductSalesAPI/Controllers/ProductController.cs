using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductSalesAPI.DTO;
using ProductSalesAPI.Filter;
using ProductSalesAPI.Helpers;
using ProductSalesAPI.Repository;
using ProductSalesAPI.Services;
using ProductSalesAPI.Wrappers;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace ProductSalesAPI.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("v1/api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private ILogger _logger;
        readonly IProductRepository _productRepository;
        private readonly IUriService uriService;

        public ProductController(ILogger<ProductController> logger, IProductRepository productRepository, IUriService uriService)
        {
            _logger = logger;
            _productRepository = productRepository;
            this.uriService = uriService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] PaginationFilter filter)
        {
            var route = Request.Path.Value;

            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

            var pagedData = _productRepository.GetAllProducts()
                    .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                    .Take(validFilter.PageSize)
                    .ToList();

            var totalRecords = _productRepository.GetAllProducts().Count();
            var pagedReponse = PaginationHelper.CreatePagedReponse<ProductDTO>(pagedData, validFilter, totalRecords, uriService, route);

            
            return Ok(pagedReponse);
       
            

            //return Ok(new PagedResponse<List<ProductDTO>>(pagedData, validFilter.PageNumber, validFilter.PageSize));
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var _product = _productRepository.GetProductById(id);

            if (_product == null)
            {
                ErrorResponse error = new ErrorResponse();

                error.error = true;
                error.content = "Not Found";
                error.message = "No product with id: " + id + " was found.";

                return NotFound(error);
            }

            return Ok(new Response<ProductDTO>(_product));

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

            return Ok(new Response<ProductCreateDTO>(productDTO));
        }

        [HttpDelete]
        [Route("{id}")]
        public int DeleteProduct(int id)
        {
            _productRepository.DeleteProduct(id);

            return id;
        }

        [HttpGet]
        [Route("search_product/{categoryName}")]
        public IActionResult SearchByCategory(string categoryName)
        {
            var prod = _productRepository.SearchProductByCategory(categoryName);

            if(prod == null)
            {
                return NotFound();
            }

            return Ok(new Response<List<ProductDTO>>(prod));
        }
    }
}
