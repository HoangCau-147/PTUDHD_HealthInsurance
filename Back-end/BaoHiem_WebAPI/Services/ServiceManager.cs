using AutoMapper;
using Contracts;
using Contracts.ClaimContracts;
using Entity.Email;
using Entity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Service.Contracts;
using Service.Contracts.Claims;
using Service.Contracts.Contracts;
using Service.Contracts.Customers;
using Service.Contracts.Insurances;
using Service.Contracts.Payments;
using Service.Contracts.Staff;
using Services.Claims;
using Services.Contracts;
using Services.Customers;
using Services.Insurances;
using Services.Payment.Momo;
using Services.Staff;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAuthenticationService> _authenticationService;
        private readonly Lazy<IEmailService> _emailService;

        //Claim
        private Lazy<IClaimHealthServiceService> _claimHealthServiceService;
        private Lazy<IClaimInvoiceService> _claimInvoiceService;
        private Lazy<IClaimPaymentService> _claimPaymentRepsitory;
        private Lazy<IClaimRequestService> _claimRequestService;

        //Customer
        private Lazy<ICustomerService> _customerService;

        //Contract
        private Lazy<IContractInvoiceService> _contractInvoiceService;
        private Lazy<IContractService> _contractService;

        //Insurance
        private Lazy<IInsuranceBenefitCostService> _insuranceBenefitCostService;
        private Lazy<IInsuranceBenefitService> _insuranceBenefitService;
        private Lazy<IInsurancePriceService> _insurancePriceService;
        private Lazy<IInsuranceProductService> _insuranceProductService;
        private Lazy<IInsuranceProgramService> _insuranceProgramService;
        private Lazy<IHealthConditionService> _healthConditionService;
        private Lazy<IInsuranceBenefitTypeService> _insuranceBenefitTypeService;
        //Staff
        private Lazy<IEmployeeService> _employeeService;

        // payment
        private Lazy<IMomoService> _momoService;
        public ServiceManager (IRepositoryManager repositoryManager,
            IMapper mapper, EmailConfiguration emailConfiguration, 
            IConfiguration configuration,
            UserManager<User> userManager, RoleManager<IdentityRole> role)
        {

            _authenticationService = new Lazy<IAuthenticationService> (() =>
            new AuthenticationService(mapper, repositoryManager, configuration, userManager, role));
            _emailService = new Lazy<IEmailService>(() => 
                new EmailService(emailConfiguration));

            //Claim
            _claimHealthServiceService = new Lazy<IClaimHealthServiceService>(() => new ClaimHealthServiceService());
            _claimInvoiceService = new Lazy<IClaimInvoiceService>(() => new ClaimInvoiceService(repositoryManager, mapper));
            _claimPaymentRepsitory = new Lazy<IClaimPaymentService>(() => new ClaimPaymentService(repositoryManager, mapper));
            _claimRequestService = new Lazy<IClaimRequestService>(() => new ClaimRequestService(repositoryManager));

            //Customer
            _customerService = new Lazy<ICustomerService>(() => new CustomerService(repositoryManager, mapper, userManager));

            //Contracts
            _contractInvoiceService = new Lazy<IContractInvoiceService>(() => new ContractInvoiceService(repositoryManager, mapper));
            _contractService = new Lazy<IContractService>(() => new ContractService(repositoryManager, mapper));

            //Insurance
            _insuranceBenefitCostService = new Lazy<IInsuranceBenefitCostService>(() => new InsuranceBenefitCostService());
            _insuranceBenefitService = new Lazy<IInsuranceBenefitService>(() => new InsuranceBenefitService(repositoryManager));
            _insurancePriceService = new Lazy<IInsurancePriceService>(() => new InsurancePriceService());
            _insuranceProductService = new Lazy<IInsuranceProductService>(() => new InsuranceProductService(repositoryManager, mapper));
            _insuranceProgramService = new Lazy<IInsuranceProgramService>(() => new InsuranceProgramService(repositoryManager, mapper));

            _healthConditionService = new Lazy<IHealthConditionService>(() => new HealthConditionService(repositoryManager, mapper));
            _insuranceBenefitTypeService = new Lazy<IInsuranceBenefitTypeService>(() => new InsuranceBenefitTypeService(repositoryManager, mapper));

            //Staff
            _employeeService = new Lazy<IEmployeeService>(() => new EmployeeService(repositoryManager, mapper, userManager));

            //payment
            _momoService = new Lazy<IMomoService>(() => new MomoService(configuration));
        }
        public IAuthenticationService AuthenticationService => _authenticationService.Value;
        public IEmailService EmailService => _emailService.Value;

        // Claim
        public IClaimHealthServiceService ClaimHealthServices => _claimHealthServiceService.Value;

        public IClaimInvoiceService ClaimInvoices => _claimInvoiceService.Value;

        public IClaimPaymentService ClaimPayments => _claimPaymentRepsitory.Value;

        public IClaimRequestService ClaimRequests => _claimRequestService.Value;

        //Customer

        public ICustomerService Customers => _customerService.Value;
        //Contracts

        public IContractService Contracts => _contractService.Value;

        public IContractInvoiceService ContractsInvoices => _contractInvoiceService.Value;
        //Insurance

        public IInsuranceBenefitCostService InsuranceBenefitCost => _insuranceBenefitCostService.Value;

        public IInsuranceBenefitService InsuranceBenefit => _insuranceBenefitService.Value;

        public IInsurancePriceService InsurancePrices => _insurancePriceService.Value;

        public IInsuranceProductService InsuranceProducts => _insuranceProductService.Value;

        public IInsuranceProgramService InsurancePrograms => _insuranceProgramService.Value;

        public IHealthConditionService HealthConditions => _healthConditionService.Value;

        public IInsuranceBenefitTypeService InsuranceBenefitType => _insuranceBenefitTypeService.Value;
        //Employee

        public IEmployeeService Employees => _employeeService.Value;

        //payment

        public IMomoService Momo => _momoService.Value;
    }
}
