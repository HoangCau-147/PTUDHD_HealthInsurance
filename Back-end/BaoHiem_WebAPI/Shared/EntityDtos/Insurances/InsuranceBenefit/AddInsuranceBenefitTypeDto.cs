using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.EntityDtos.Insurances.InsuranceBenefit
{
    public class AddInsuranceBenefitTypeDto
    {
        public string? Name { get; set; }
        public List<AddInsuranceBenefitDto> benefits { get; set; }
    }
}
