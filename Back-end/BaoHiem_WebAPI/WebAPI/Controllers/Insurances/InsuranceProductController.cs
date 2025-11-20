using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.EntityDtos.Insurances.InsuranceProduct;

namespace WebAPI.Controllers.Insurances
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceProductController : ControllerBase
    {
        private IServiceManager _serviceManager;
        public InsuranceProductController(IServiceManager serviceManager) { 
            this._serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _serviceManager.InsuranceProducts.GetAll(false);
            return StatusCode(StatusCodes.Status200OK, products);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _serviceManager.InsuranceProducts.GetById(id, false);
            return StatusCode(StatusCodes.Status200OK, product);
        }
        [HttpPost]
        public async Task<IActionResult> CreateInsuranceProduct([FromBody] AddInsuranceProductDto insuranceProductDto)
        {
            if(insuranceProductDto == null)
            {
                return BadRequest();
            }
            await _serviceManager.InsuranceProducts.AddInsuranceProduct(insuranceProductDto);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductDto updateProductDto)
        {
            await _serviceManager.InsuranceProducts.UpdateProduct(updateProductDto);
            return StatusCode(StatusCodes.Status200OK);
        }
        [HttpPut("disable/{productId}")]
        public async Task<IActionResult> DisableProduct(int productId)
        {
            await _serviceManager.InsuranceProducts.DisableProduct(productId);
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
