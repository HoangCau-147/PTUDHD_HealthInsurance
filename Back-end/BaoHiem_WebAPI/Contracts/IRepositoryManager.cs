using Contracts.ClaimContracts;
using Contracts.CustomerContracts;
using Contracts.InsuranceContractContracts;
using Contracts.InsuranceContracts;
using Contracts.StaffContracts;
using Entity.Models;
using Microsoft.AspNetCore.Identity;
using Service.Contract.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        //metheo
        IUserRepository Users { get; }
        IRoleRepository Role { get; }

        //Claim
        IClaimHealthServiceRepository ClaimHealthServices { get; }
        IClaimInvoiceRepository ClaimInvoices {  get; } 
        IClaimPaymentRepository ClaimPayments { get; }
        IClaimRequestRepository ClaimRequests { get; }
        //Customer
        ICustomerRepository Customers { get; }
        //contracts
        IContractRepository Contracts {  get; } 
        IContractInvoiceRepository ContractsInvoices { get; }

        //Insurance
        IInsuranceBenefitCostRepository InsuranceBenefitCost {  get; }
        IInsuranceBenefitRepository InsuranceBenefit { get; }
        IInsuranceBenefitTypeRepository InsuranceBenefitType { get; }
        IInsurancePriceRepository InsurancePrices { get; }
        IInsuranceProductRepository InsuranceProducts { get; }
        IInsuranceProgramRepository InsurancePrograms { get; }
        IHealthConditionRepository HealthConditions { get; }
        //Staff
        IEmployeeRepository Employees { get; }

        Task SaveAsync();
        void Save();
    }
}
