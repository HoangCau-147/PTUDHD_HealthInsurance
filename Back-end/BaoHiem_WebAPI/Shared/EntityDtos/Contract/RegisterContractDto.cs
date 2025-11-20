using Shared.EntityDtos.Customer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.EntityDtos.Contract
{
    public class RegisterContractDto
    {
        [Required]
        public int ProductId { get; init; }
        [Required]
        public int ProgramId { get; set; }
        [Required]
        public DateTime StartDate { get; init; }
        [Required]
        public DateTime EndDate { get; init; }
        [Required]
        public float TotalPrice { get; init; }
        public string HealthDeclaration { get; set; }

        [Required]
        public int PaymentMethod { get; init; }
        [Required]
        public CustomerDto Customer { get; init; }
        [Required]
        public List<RegisterContractHealthConditionDto>? HealthConditions { get; init; }
    }
    public enum PaymentMehtod
    {
        MOMO,
        Cash
    }
}
