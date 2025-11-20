using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models.Claim
{
    public class ClaimHealthService
    {
        [Key]
        public Guid Id { get; set; }
        [Key]
        public Guid ClaimPaymentId { get; set; }
        public string? ServiceName { get; set; }
        public int? CostOfATreatment { get; set; }
        public string? HospitalName { get; set; }
        public DateTime? UsedDate { get; set; }
        public ClaimPayment? ClaimPayment { get; set; }
    }

}