using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.EntityDtos.Contract
{
    public class ContractHealthConditionDto
    {
        public int ConditionId { get; set; }
        public string ConditionName { get; set; }
        public bool Status { get; set; }
    }
}
