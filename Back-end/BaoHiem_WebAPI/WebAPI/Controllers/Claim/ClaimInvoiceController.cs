using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace WebAPI.Controllers.Claim
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimInvoiceController : ControllerBase
    {
        private readonly IServiceManager _service;
        public ClaimInvoiceController(IServiceManager serviceManager) { 
            _service = serviceManager;
        }
        [HttpGet] 
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.ClaimInvoices.GetAll());
        }

    }
}
