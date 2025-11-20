using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.EntityDtos.Payment.Momo.Request
{
    public class MomoOneTimePaymentRequestDto
    {
        public string amount { get; set; }
        public string orderId { get; set; } = string.Empty;
        public string orderInfo {  get; set; } = string.Empty;
    }
}
