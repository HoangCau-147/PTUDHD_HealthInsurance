using Shared.EntityDtos.Insurances.InsuranceProgram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.EntityDtos.Insurances.InsuranceBenefit
{
    public class InsuranceBenefitProductDto
    {
        public int BenefitId { get; set; }
        public string? BenefitName { get; set; }
        public string? Description { get; set; }
        public List<BenefitProgramCostDto> benefitProgramCosts { get; set; }
    }
}
