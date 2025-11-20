using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.EntityDtos.Claim;

namespace WebAPI.Controllers.Claim
{
    [Route("api/claim/payment")]
    [ApiController]
    public class ClaimPaymentController : ControllerBase
    {
        private readonly IServiceManager _service;
        public ClaimPaymentController(IServiceManager serviceManager)
        {
            _service = serviceManager;
        }
        [HttpPost] 
        public async Task<IActionResult> AddPayment([FromBody] CreateClaimPaymentDto createClaimPaymentDto)
        {
            await _service.ClaimPayments.AddPayment(createClaimPaymentDto);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.ClaimPayments.GetAll());
        }
        [Authorize(Roles ="Employee")]
        [HttpPut]
        public async Task<IActionResult> UpdateStatus(Guid paymentId)
        {
            var empEmail = HttpContext.User.Claims.ElementAt(0).Value;
            await _service.ClaimPayments.UpdateStatus(paymentId, empEmail);
            return Ok();
        }
        [HttpGet("{CustomerId}/report")]
        public async Task<IActionResult> GetReport(int CustomerId)
        {
            var result = await _service.ClaimPayments.GetReport(CustomerId);
            return Ok(result);
        }
    }

}
