using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.EntityDtos.Contract;

namespace WebAPI.Controllers.Contracts
{
    [Route("api/contract/invoices")]
    [ApiController]
    public class ContractInvoiceController : ControllerBase
    {
        private readonly IServiceManager _service;
        public ContractInvoiceController(IServiceManager serviceManager)
        {
            this._service = serviceManager;
        }
        [HttpGet]
        public async Task<IActionResult> GetInvoice(Guid contractId)
        {
            var result = await _service.ContractsInvoices.GetInvoiceByContractId(contractId);
            return Ok(result);
        }
        [HttpGet("report/{year}")]
        public async Task<IActionResult> GetReports(int year)
        {
            var result = await _service.ContractsInvoices.GetReportByYear(year);
            return Ok(result);
        }
        [HttpGet("/customer/{customerId}/report/{year}")]
        public async Task<IActionResult> GetCustomerReports(int customerId, int year)
        {
            var result = await _service.ContractsInvoices.GetCustomerReportByYear(customerId, year);
            return Ok(result);
        }

    }
}
