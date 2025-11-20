using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.EntityDtos.Insurances.InsuranceBenefit
{
    public class InsuranceBenefitDto
    {
        public int BenefitId { get; set; }
        public string? BenefitName { get; set; }
        public string? Description { get; set; }
    }
}
