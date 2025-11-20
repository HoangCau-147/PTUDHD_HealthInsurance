using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models.InsuranceModels
{
    public class InsuranceBenefitType
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BenefitTypeId { get; set; }
        public string? Name { get; set; }
        public List<InsuranceBenefit> Benefits { get; set; }
        public List<InsuranceProduct> Products { get; set; }
    }
}
