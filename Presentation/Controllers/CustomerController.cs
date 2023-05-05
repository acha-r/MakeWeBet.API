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
    public class CustomerController : ControllerBase
    {
        private readonly IServiceManager _service;

        public CustomerController(IServiceManager service) =>
            _service = service;

        [Route("barcode")]
        [HttpGet]
        public IActionResult GetBarcodeInfo(int customerId)
        {
            var userDetail = _service.CustomerService.GetBarcodeInfo(customerId, trackChanges: false);

            if (userDetail == null)
                return NotFound("This id no correct");

            return Ok(userDetail);
        }

        [Route("payment")]
        [HttpPut]
        public IActionResult MakePayment(int customerId , int productId)
        {
            try
            {
                var completePayment = _service.CustomerService.MakePayment(customerId, productId, trackChanges: true);

                return Ok(completePayment);
            }
            catch (Exception)
            {
                return BadRequest ("Dem neva register this product");
            }
        }
    }
}
