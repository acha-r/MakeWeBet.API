using Microsoft.AspNetCore.Mvc;
using Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IServiceManager _service;

        public StoreController(IServiceManager service) =>
            _service = service;

        [Route("api/product_registration")]
        [HttpPut]
        public IActionResult RegisterProduct(int productId)
        {
            try
            {
                var product = _service.StoreService.RegisterProduct(productId, trackChanges: true);
                return Ok(product);
            }
            catch (Exception)
            {
                return BadRequest("The store no dey");
            }

        }
    }
}
