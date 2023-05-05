using Microsoft.AspNetCore.Mvc;
using Service.Contract;
using SharedDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IServiceManager _service;

        public ProductController(IServiceManager service) => 
            _service = service;

        [HttpGet]
        public IActionResult GetProductInfo(int productId) 
        {
            try
            {
                var product = _service.ProductService.GetProductInfo(productId, trackChanges: false);
                
                return Ok(product);
            }
            catch 
            {
                return StatusCode(500, "Our server don misbehave");
            }
        }
        
        [HttpPost]
        public IActionResult AddProduct([FromBody] ProductDto product)
        {
            try
            {
                if (product is null)
                    return BadRequest("You no enter anything");
                var newProduct = _service.ProductService.AddProduct(product);
                return Ok(newProduct);
            }
            catch (Exception)
            {
                return BadRequest("The store no dey");
            }
            
        }
       
        
    }
}
