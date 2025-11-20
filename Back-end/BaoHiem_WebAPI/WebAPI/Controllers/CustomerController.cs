using Entity.Models.Claim;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.EntityDtos.Customer;
using Shared.ResponseApi;

namespace WebAPI.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IServiceManager _services;
        public CustomerController(IServiceManager serviceManager) { 
            this._services = serviceManager;
        }
        [HttpGet("{email}")]
        public async Task<IActionResult> GetCustomerByEmail(string email) {
            var result = await _services.Customers.GetCustomerByEmail(email);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetCustomer()
        {
            return Ok(await _services.Customers.GetCustomers());
        }
        [Authorize(Roles ="Customer")]
        [HttpGet("getinformation")] 
        public async Task<IActionResult> GetInformation()
        {
            var customerEmail = HttpContext.User.Claims.ElementAt(0).Value;
            var customer = await _services.Customers.GetCustomerByEmail(customerEmail);
            return Ok(customer);
        }
        [Authorize(Roles = "Customer")]
        [HttpGet("claim")]
        public async Task<IActionResult> GetRequestOfCustomer(RequestStatus status)
        {
            var customerEmail = HttpContext.User.Claims.ElementAt(0).Value;
            var customer = await _services.Customers.GetCustomerByEmail(customerEmail);
            var result = await _services.ClaimRequests.GetClaimRequestOfCustomer((int)customer.CustomerId, status);
            if (result == null)
            {
                return NoContent();
            }
            return Ok(result);
        }
        [HttpPut] 
        public async Task<IActionResult> UpdateCustomer(int customerId, UpdateCustomerDto updateCustomerDto)
        {
            await _services.Customers.UpdateCustomer(customerId, updateCustomerDto);
            var response = new Shared.ResponseApi.Response
            {
                Status = "200",
                Message = "Câp nhật thành công"
            };
            return Ok(response);
        }
    }
}
