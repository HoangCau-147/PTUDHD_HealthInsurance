using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Models.InsuranceModels;

namespace Entity.Models.InsuranceContractModels
{
    public class ContractHealthCondition
    {
        [Key]
        public Guid ContractId { get; set; }
        public Contract? Contract { get; set; }
        [Key]
        public Guid HealthConditionId { get; set; }
        public HealthCondition? HealthCondition { get; set; }
        public bool Status { get; set; }
    }
}
