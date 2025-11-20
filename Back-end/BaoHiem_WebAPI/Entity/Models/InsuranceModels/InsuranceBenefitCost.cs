using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models.InsuranceModels
{
    public class InsuranceBenefitCost
    {

        [Key]
        public Guid BenefitId { get; set; }
        [Key]
        public Guid PolicyId { get; set; }
        [Key]
        public Guid ProgramId { get; set; }
        public InsuranceProduct? Product { get; set; }
        public InsuranceBenefit? Benefit { get; set; }
        public InsuranceProgram? Program { get; set; }
        public float? Cost { get; set; }
    }
}
