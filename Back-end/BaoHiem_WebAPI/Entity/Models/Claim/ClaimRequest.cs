using Entity.Models.Customers;
using Entity.Models.InsuranceContractModels;
using Entity.Models.Staff;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models.Claim
{
    public class ClaimRequest
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime? CreatedDate {  get; set; }
        //public string? MedicalCondition {  get; set; }
        //public string? MedicalHistory { get; set; }
        public string? Status { get; set; }
        public string HospitalBillAmount { get; set; } // Số tiền hóa đơn viện phí
        public Guid? CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public Contract? Contract { get; set; }
        public Guid? ContractId { get; set; }
    }
    public enum RequestStatus
    {
        Waiting,
        Processing,
        Accepted,
        Denied
    }
}
