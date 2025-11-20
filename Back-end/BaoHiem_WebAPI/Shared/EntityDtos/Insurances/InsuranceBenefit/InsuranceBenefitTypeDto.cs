using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.EntityDtos.Insurances.InsuranceBenefit
{
    public class InsuranceBenefitTypeDto
    {
        public int BenefitTypeId { get; set; }
        public string? Name { get; set; }
        public List<InsuranceBenefitDto> Benefits { get; set; }
    }
}
