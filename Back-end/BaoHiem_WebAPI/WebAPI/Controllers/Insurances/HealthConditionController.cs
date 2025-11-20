using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.EntityDtos.Insurances.HealthCondition;

namespace WebAPI.Controllers.Insurances
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthConditionController : ControllerBase
    {
        private readonly IServiceManager _service;
        public HealthConditionController(IServiceManager serviceManager)
        {
            this._service = serviceManager;
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetHealthConditionById(int id)
        {
            return Ok(await _service.HealthConditions.GetById(id));
        }
        [HttpGet]
        public async Task<IActionResult> GetHealthConditions()
        {
            return Ok(await _service.HealthConditions.GetAll());
        }
        [HttpPost]
        public async Task<IActionResult> AddHealthCondition([FromBody] AddHealthConditionDto addHealthConditionDto)
        {
            return Ok(await _service.HealthConditions.AddCondtions(addHealthConditionDto));
        }
    }
}
