using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.EntityDtos.Claim
{
    public class ClaimPaymentDto
    {
        public Guid Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public float? TotalCost { get; set; }
        public Guid? RequestID { get; set; }
        public string? Status { get; set; }
        public string? Customer {  get; set; }
        public string? CCCD { get; set; }
        public string? Product {  get; set; }
        public string? Program { get; set; }
        public List<ClaimHealthDto> claims { get; set; }
    }
}
