using Contracts.ClaimContracts;
using Contracts.CustomerContracts;
using Contracts.InsuranceContractContracts;
using Contracts.InsuranceContracts;
using Contracts.StaffContracts;
using Entity.Models;
using Microsoft.AspNetCore.Identity;
using Service.Contract.Claims;
using Service.Contracts.Claims;
using Service.Contracts.Contracts;
using Service.Contracts.Customers;
using Service.Contracts.Insurances;
using Service.Contracts.Payments;
using Service.Contracts.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IServiceManager
    {
        //Claim
        IClaimHealthServiceService ClaimHealthServices { get; }
        IClaimInvoiceService ClaimInvoices { get; }
        IClaimPaymentService ClaimPayments { get; }
        IClaimRequestService ClaimRequests { get; }
        //Customer
        ICustomerService Customers { get; }
        //contracts
        IContractService Contracts { get; }
        IContractInvoiceService ContractsInvoices { get; }

        //Insurance
        IInsuranceBenefitCostService InsuranceBenefitCost { get; }
        IInsuranceBenefitService InsuranceBenefit { get; }
        IInsurancePriceService InsurancePrices { get; }
        IInsuranceProductService InsuranceProducts { get; }
        IInsuranceProgramService InsurancePrograms { get; }
        IHealthConditionService HealthConditions { get; }
        IInsuranceBenefitTypeService InsuranceBenefitType { get; }
        //Staff
        IEmployeeService Employees { get; }
        IAuthenticationService AuthenticationService { get; }
        IEmailService EmailService { get; }

        // payment
        IMomoService Momo { get; }
    }
}
