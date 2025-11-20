using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.EntityDtos.Insurances.InsuranceBenefit;

namespace WebAPI.Controllers.Insurances
{
    [Route("api/benefitType/{benefitTypeId}/benefit")]
    [ApiController]
    public class InsuranceBenefitController : ControllerBase
    {
        private readonly IServiceManager _service;
        public InsuranceBenefitController(IServiceManager serviceManager) {
            _service = serviceManager;
        }
        [HttpPost] 
        public async Task<IActionResult> AddBenefit(int benefitTypeId, [FromBody] AddInsuranceBenefitDto benefitDto)
        {
            await _service.InsuranceBenefit.AddBenefit(benefitTypeId, benefitDto);
            return StatusCode(StatusCodes.Status201Created, "Benefit was created");
        }
    }
}
