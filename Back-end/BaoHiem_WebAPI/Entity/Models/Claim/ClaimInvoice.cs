using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models.Claim
{
    public class ClaimInvoice
    {
        [Key]
        public Guid Id { get; set; }
        public float TotalCost { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid PaymentID { get; set; }
        public ClaimPayment? Payment { get; set; }
    }

    
}
