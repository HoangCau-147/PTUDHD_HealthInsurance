using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.EntityDtos.Claim
{
    public class CLaimInvoiceDto
    {
        public Guid Id { get; set; }
        public float TotalCost { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid PaymentID { get; set; }
    }
}
