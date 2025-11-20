using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace WebAPI.Controllers.Staff
{
    [Route("api/[controller]")]
    //[Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public EmployeeController(IServiceManager serviceManager) 
        {
            this._serviceManager = serviceManager;
        }

        [HttpGet("{EmployeeId:int}")]
        public async Task<IActionResult> GetEmployee(int EmployeeId)
        {
            var employee =  await _serviceManager.Employees.GetEmployee(EmployeeId);
            return Ok(employee);
        }
        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _serviceManager.Employees.GetEmployees(false);
            return Ok(employees);
        }
        [HttpGet("{email}")]
        public async Task<IActionResult> GetEmployeeByEmail(string email)
        {
            var employees = await _serviceManager.Employees.GetEmployeeByEmail(email);
            return Ok(employees);
        }
    }
}
