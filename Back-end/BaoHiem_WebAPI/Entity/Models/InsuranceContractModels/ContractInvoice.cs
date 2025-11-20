using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models.InsuranceContractModels
{
    public class ContractInvoice
    {
        [Key]
        public Guid Id { get; set; }
        [Key]
        public Guid ContractID { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InvoiceId { get; set; }
        public float? LastPrice { get; set; } = 0;
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public Contract? Contract { get; set; }
    }
}
