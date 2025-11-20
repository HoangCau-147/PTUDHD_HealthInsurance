using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.EntityDtos.Contract
{
    public class CreateContractInvoiceDto
    {
        public int LastPrice { get; init; } = 0;
        public string InvoiceInfo { get; init; }
        public string PaymentMethod { get; init; }
        public Guid ContractId { get; init; }
    }
}
