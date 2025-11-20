using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.EntityDtos.Contract
{
    public class ReportContractByYearDto
    {
        public int Month { get; set; }
        public float? Contract { get; set; }
        public float? Request { get; set; }
    }
}
