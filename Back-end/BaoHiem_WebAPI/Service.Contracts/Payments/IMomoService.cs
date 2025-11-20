using Newtonsoft.Json.Linq;
using Shared.EntityDtos.Payment.Momo.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Service.Contracts.Payments
{
    public interface IMomoService
    {
        string PaymentRequest(MomoOneTimePaymentRequestDto paymentRequestDto);
    }
}
