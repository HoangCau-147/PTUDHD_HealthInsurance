using Shared.EntityDtos.Insurances.InsuranceProgram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.EntityDtos.Insurances.InsuranceBenefit
{
    public class AddBenefitProductDto
    {
        public int BenefitId { get; set; }
        public int Price { get; set; }
    }
}
