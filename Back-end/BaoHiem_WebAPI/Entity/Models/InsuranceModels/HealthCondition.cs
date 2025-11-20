using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Models.InsuranceContractModels;

namespace Entity.Models.InsuranceModels
{
    public class HealthCondition
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HealthConditionId { get; set; }
        public string? Name { get; set; }
        public string? Question { get; set; }
        public ICollection<ContractHealthCondition>? contracts { get; set; }
        public Guid ProductId { get; set; }
        public InsuranceProduct? Product { get; set; }
    }
}
