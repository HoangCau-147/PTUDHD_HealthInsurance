using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.EntityDtos.Claim
{
    public class CreateClaimHeathDto
    {
        public string ServiceName { get; set; }
        public int CostOfATreatment { get; set; }
        public string HospitalName { get; set; }
        public DateTime UsedDate { get; set; }
    }
}
