using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.EntityDtos.Insurances.InsuranceProgram
{
    public class AddBenefitProgramCostDto
    {
        public int ProgramId { get; set; }
        public int Cost { get; init; }
    }
}
