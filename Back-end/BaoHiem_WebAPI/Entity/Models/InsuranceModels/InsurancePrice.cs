using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models.InsuranceModels
{
    public class InsurancePrice
    {
        public InsurancePrice() 
        { 

        }
        [Key]
        public Guid PolicyId { get; set; }
        [Key]
        public Guid ProgramId { get; set; }
        public float Price {  get; set; }
        public InsuranceProduct? Product { get; set; }
        public InsuranceProgram? Program { get; set; }
    }
}
