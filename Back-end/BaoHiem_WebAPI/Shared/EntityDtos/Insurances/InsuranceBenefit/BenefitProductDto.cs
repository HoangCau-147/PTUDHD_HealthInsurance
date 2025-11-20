using Shared.EntityDtos.Insurances.InsuranceProgram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.EntityDtos.Insurances.InsuranceBenefit
{
    public class BenefitProductDto
    {
        public int BenefitId { get; set; }
        public string? BenefitName { get; set; }
        public string? Description { get; set; }
        public List<BenefitProgramCostDto> benefitProgramCostDtos { get; set; }
    }
}
