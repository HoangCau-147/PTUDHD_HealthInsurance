using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models.InsuranceModels
{
    public class InsuranceProgram
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProgramId { get; set; }
        public string? Name { get; set; } 
        public string? NormalizedName { get; set; }
        public float Multiplier { get; set; } = 1;
        public List<InsuranceBenefitCost> Benefits { get; set; }
        public List<InsurancePrice> Prices { get; set; }
    }
}
