using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.EntityDtos.Contract
{
    public class ContractInvoiceDto
    {
        public int InvoiceId { get; set; }
        public int LastPrice { get; set; } = 0;
        public string PaymentMethod { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
