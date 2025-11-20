using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.EntityDtos.Insurances;
using Shared.EntityDtos.Insurances.InsuranceProgram;

namespace WebAPI.Controllers.Insurances
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuraceProgramController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public InsuraceProgramController(IServiceManager serviceManager)
        { 
            this._serviceManager = serviceManager;
        }
        [HttpPost] 
        public async Task<IActionResult> AddInsuranceProgram([FromBody] AddInsuranceProgramDto addInsuranceProgramDto)
        {
            var result = await _serviceManager.InsurancePrograms.AddPrograms(addInsuranceProgramDto);
            return StatusCode(StatusCodes.Status201Created, result);
        }
        [HttpGet]
        public async Task<IActionResult> GetPrograms()
        {
            var result = await _serviceManager.InsurancePrograms.GetPrograms(false);
            return Ok(result);
        }
    }
}
