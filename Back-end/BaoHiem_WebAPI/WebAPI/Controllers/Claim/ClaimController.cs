using Entity.Models.Claim;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.EntityDtos.Claim;

namespace WebAPI.Controllers.Claim
{
    [Route("api/claim")]
    [ApiController]
    public class ClaimController : ControllerBase
    {
        private readonly IServiceManager _service;
        public ClaimController(IServiceManager serviceManager)
        {
            _service = serviceManager;
        }
        [HttpPost]
        public async Task<IActionResult> AddRequest([FromBody] CreateClaimRequestDto claimRequestDto)
        {
            await _service.ClaimRequests.CreateRequest(claimRequestDto);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpGet("CustomerId")] 
        public async Task<IActionResult> GetRequestOfCustomer(int customerId, RequestStatus status)
        {
            var result = await _service.ClaimRequests.GetClaimRequestOfCustomer(customerId, status);
            if (result == null)
            {
                return NoContent();
            }
            return Ok(result);
        }
        [HttpGet("status/{status}")]
        public async Task<IActionResult> GetRequestsByStatus(RequestStatus status)
        {
            return Ok(await _service.ClaimRequests.GetClaimRequestByStatus(status));
        }
        [HttpPut]
        public async Task<IActionResult> DenyRequest(Guid requestId)
        {
            await _service.ClaimRequests.DenyRequest(requestId);
            return Ok();
        }
    }
}
