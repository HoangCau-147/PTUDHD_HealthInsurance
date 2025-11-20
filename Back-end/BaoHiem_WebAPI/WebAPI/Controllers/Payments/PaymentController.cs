using Entity.Models.InsuranceContractModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Asn1.Ocsp;
using Service.Contracts;
using Shared.EntityDtos.Contract;
using Shared.EntityDtos.Payment.Momo.Request;
using Shared.EntityDtos.Payment.Momo.Response;
using Shared.Helper.Momo;

namespace WebAPI.Controllers.Payments
{
    [Route("api/payment")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IServiceManager _service;
        public PaymentController(IServiceManager service) { 
            this._service = service;
        }
        [HttpPost("momo-payment")]
        public IActionResult Payment([FromBody] MomoOneTimePaymentRequestDto paymentRequest)
        {
            var paymentUrl = _service.Momo.PaymentRequest(paymentRequest);
            return Ok(paymentUrl.ToString());
        }
        //[HttpGet("momo-return")]
        //public async Task<IActionResult> ConfirmPaymentClient(string partnerCode, string accessKey, 
        //    string requestId, string orderId, string orderInfo, 
        //    string orderType, string transId, string message, string localMessage, 
        //    string responseTime, string errorCode, string payType, string? extraData, 
        //    string signature)
        //{
        //    if(errorCode == "0")
        //    {
        //        await _service.Contracts.UpdateStatus(Guid.Parse(orderId), ContractStatus.Using);
        //        var invoiceDto = new CreateContractInvoiceDto
        //        {
        //            ContractId = Guid.Parse(orderId),
        //            InvoiceInfo = orderInfo,
        //            PaymentMethod = PaymentMehtod.MOMO.ToString()
        //        };
        //        await _service.ContractsInvoices.addContractInvoice(invoiceDto);
        //        return Ok("Thanh toán thành công");
        //    }
        //    else
        //    {
        //        return BadRequest(new {errorCode, message});
        //    }
        //}
    }
}
