using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models.InsuranceModels
{
    public class InsuranceBenefit
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BenefitId { get; set; }
        public string? BenefitName {  get; set; }
        public string? Description { get; set; }

        public Guid? BenefitTypeId { get; set; }
        public InsuranceBenefitType BenefitType { get; set; }
    }
}
