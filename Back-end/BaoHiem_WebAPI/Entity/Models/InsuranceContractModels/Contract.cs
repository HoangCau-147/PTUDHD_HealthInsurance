using Entity.Models.Customers;
using Entity.Models.InsuranceModels;
using Entity.Models.Staff;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models.InsuranceContractModels
{
    public class Contract
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ContractId { get; set; } = new Guid();
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? ConfirmDate { get; set; }
        public float? TotalPrice { get; set; }
        public string? Status { get; set; }
        public string? HealthDeclaration { get; set; }
        public Guid? CustomerID { get; set; }
        public Guid? EmployeeID { get; set; }
        public Guid? InsuranceProductId { get; set; }
        public Guid? InsuranceProgramId { get; set; }
        public Customer? Customer { get; set; }
        public Employee? Employee { get; set; }
        public InsuranceProduct? InsuranceProduct { get; set;}
        public InsuranceProgram? InsuranceProgram { get; set; }
        public ICollection<ContractHealthCondition>? ContractHealthConditions { get; set; }
    }
    public enum ContractStatus
    {
        Unpaid, //0
        Cancelled, // 1
        Using, // 2
        Expired, //3
    }
}
