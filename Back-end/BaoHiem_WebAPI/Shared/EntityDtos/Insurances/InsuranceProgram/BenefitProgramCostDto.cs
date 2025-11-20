using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.EntityDtos.Insurances.InsuranceProgram
{
    public class BenefitProgramCostDto
    {
        public int ProgramId { get; set; }
        public string? ProgramName { get; set; }
        public float? Price { get; set; }
    }
}
