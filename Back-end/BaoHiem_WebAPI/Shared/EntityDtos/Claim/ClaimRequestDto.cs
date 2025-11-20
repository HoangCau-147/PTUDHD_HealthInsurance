using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.EntityDtos.Claim
{
    public class ClaimRequestDto
    {
        public Guid ClaimRequestId { get; set; }
        public DateTime? CreatedDate { get; set; }
        //public string? MedicalCondition { get; set; }
        //public string? MedicalHistory { get; set; }
        public string? Status { get; set; }
        public Guid? ContractId { get; set; }
        public string? ProductName { get; set; }
        public int? CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string ProgramName { get; set; }
        public string HospitalBillAmount { get; set; }
    }
}
