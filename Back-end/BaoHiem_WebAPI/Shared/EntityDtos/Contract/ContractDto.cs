using Shared.EntityDtos.Customer;
using Shared.EntityDtos.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.EntityDtos.Contract
{
    public class ContractDto
    {
        public Guid ContractId { get; set; }
        public DateTime? StartDate { get; set; } = DateTime.Now;
        public DateTime? EndDate { get; set; } = DateTime.Now;
        public DateTime? ConfirmDate { get; set; } = DateTime.Now;
        public float? TotalPrice { get; set; }
        public string? Status { get; set; }
        public CustomerDto? Customer { get; set; }
        public EmployeeDto? Employee { get; set; }
        public string? HealthDeclaration { get; set; }
        public string ProductName { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public int ProductId { get; set; }
        public string? ProgramName { get; set; }
        public int? ProgramId { get; set; }
        public ICollection<ContractHealthConditionDto>? ContractHealthConditions { get; set; }
    }
}
