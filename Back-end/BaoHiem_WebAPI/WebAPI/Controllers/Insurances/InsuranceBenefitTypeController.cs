using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.EntityDtos.Insurances.InsuranceBenefit;

namespace WebAPI.Controllers.Insurances
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceBenefitTypeController : ControllerBase
    {
        private readonly IServiceManager _service;
        public InsuranceBenefitTypeController(IServiceManager serviceManager)
        {
            this._service = serviceManager;
        }
        [HttpPost]
        public async Task<IActionResult> AddBenefitType([FromBody] AddInsuranceBenefitTypeDto addInsuranceBenefitTypeDto)
        {
            var result = await _service.InsuranceBenefitType.AddBenefitType(addInsuranceBenefitTypeDto);

            return StatusCode(StatusCodes.Status201Created, result);
        }
        [HttpGet]
        public async Task<IActionResult> GetBenefitTypes()
        {
            var result = await _service.InsuranceBenefitType.GetBenefitTypes();
            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}
