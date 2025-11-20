using Contracts;
using Contracts.ClaimContracts;
using Contracts.CustomerContracts;
using Contracts.InsuranceContractContracts;
using Contracts.InsuranceContracts;
using Contracts.StaffContracts;
using Entity.Models;
using Microsoft.AspNetCore.Identity;
using Repository.EntitiesRepository;
using Repository.EntitiesRepository.Claim;
using Repository.EntitiesRepository.Contracts;
using Repository.EntitiesRepository.Customers;
using Repository.EntitiesRepository.Insurance;
using Repository.EntitiesRepository.Staff;
using Service.Contract.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private InsuranceDBContext _dbContext;
        private Lazy<IUserRepository> _userRepository;
        private Lazy<IRoleRepository> _roleRepository;

        //Claim
        private Lazy<IClaimHealthServiceRepository> _claimHealthServiceRepository;
        private Lazy<IClaimInvoiceRepository> _claimInvoiceRepository;
        private Lazy<IClaimPaymentRepository> _claimPaymentRepsitory;
        private Lazy<IClaimRequestRepository> _claimRequestRepository;

        //Customer
        private Lazy<ICustomerRepository> _customerRepository;

        //Contract
        private Lazy<IContractInvoiceRepository> _contractInvoiceRepository;
        private Lazy<IContractRepository> _contractRepository;

        //Insurance
        private Lazy<IInsuranceBenefitCostRepository> _insuranceBenefitCostRepository;
        private Lazy<IInsuranceBenefitRepository> _insuranceBenefitRepository;
        private Lazy<IInsurancePriceRepository> _insurancePriceRepository;
        private Lazy<IInsuranceProductRepository> _insuranceProductRepository;
        private Lazy<IInsuranceProgramRepository> _insuranceProgramRepository;
        private Lazy<IInsuranceBenefitTypeRepository> _insuranceBenefitTypeRepository;

        private Lazy<IHealthConditionRepository> _healthConditionRepository;
        //Staff
        private Lazy<IEmployeeRepository> _employeeRepository;

        // payment
         


        public RepositoryManager(InsuranceDBContext insuranceDBContext) { 
            _dbContext = insuranceDBContext;
            _userRepository = new Lazy<IUserRepository>(() => new UserReporitory(_dbContext));
            _roleRepository = new Lazy<IRoleRepository>(() => new RoleRepository(_dbContext));

            //Claim
            _claimHealthServiceRepository = new Lazy<IClaimHealthServiceRepository>(() => new ClaimHealthServiceRepository(_dbContext));
            _claimInvoiceRepository = new Lazy<IClaimInvoiceRepository>(() => new ClaimInvoiceRepository(_dbContext));
            _claimPaymentRepsitory = new Lazy<IClaimPaymentRepository>(() => new ClaimPaymentRepository(_dbContext));
            _claimRequestRepository = new Lazy<IClaimRequestRepository>(() => new ClaimRequestRepository(_dbContext));

            //Customer
            _customerRepository = new Lazy<ICustomerRepository>(() => new CustomerRepository(_dbContext));

            //Contracts
            _contractInvoiceRepository = new Lazy<IContractInvoiceRepository>(() => new ContractInvoiceRepository(_dbContext));
            _contractRepository = new Lazy<IContractRepository>(() => new ContractRepository(_dbContext));

            //Insurance
            _insuranceBenefitCostRepository = new Lazy<IInsuranceBenefitCostRepository>(() => new InsuranceBenefitCostRepository(_dbContext));
            _insuranceBenefitRepository = new Lazy<IInsuranceBenefitRepository>(() => new InsuranceBenefitRepository(_dbContext));
            _insurancePriceRepository = new Lazy<IInsurancePriceRepository>(() => new InsurancePriceRepository(_dbContext));
            _insuranceProductRepository = new Lazy<IInsuranceProductRepository>(() => new InsuranceProductRepository(_dbContext));
            _insuranceProgramRepository = new Lazy<IInsuranceProgramRepository>(() => new InsuranceProgramRepository(_dbContext));
            _healthConditionRepository = new Lazy<IHealthConditionRepository>(() => new HealthConditionRepository(_dbContext));
            _insuranceBenefitTypeRepository = new Lazy<IInsuranceBenefitTypeRepository>(() => new InsuranceBenefitTypeRepository(_dbContext));
            //Staff
            _employeeRepository = new Lazy<IEmployeeRepository>(() => new EmployeeRepository(_dbContext));
        }

        public IUserRepository Users => _userRepository.Value;

        public IRoleRepository Role => _roleRepository.Value;

        //Claim
        public IClaimHealthServiceRepository ClaimHealthServices => _claimHealthServiceRepository.Value;

        public IClaimInvoiceRepository ClaimInvoices => _claimInvoiceRepository.Value;

        public IClaimPaymentRepository ClaimPayments => _claimPaymentRepsitory.Value;

        public IClaimRequestRepository ClaimRequests => _claimRequestRepository.Value;

        //Customer
        public ICustomerRepository Customers => _customerRepository.Value;

        //Contracts
        public IContractRepository Contracts => _contractRepository.Value;

        public IContractInvoiceRepository ContractsInvoices => _contractInvoiceRepository.Value;

        //Insurance
        public IInsuranceBenefitCostRepository InsuranceBenefitCost => _insuranceBenefitCostRepository.Value;

        public IInsuranceBenefitRepository InsuranceBenefit => _insuranceBenefitRepository.Value;

        public IInsurancePriceRepository InsurancePrices => _insurancePriceRepository.Value;

        public IInsuranceProductRepository InsuranceProducts => _insuranceProductRepository.Value;

        public IInsuranceProgramRepository InsurancePrograms => _insuranceProgramRepository.Value;
        public IInsuranceBenefitTypeRepository InsuranceBenefitType => _insuranceBenefitTypeRepository.Value;


        //Staff
        public IEmployeeRepository Employees => _employeeRepository.Value;

        public IHealthConditionRepository HealthConditions => _healthConditionRepository.Value;


        // Methods
        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
        public void Save() => _dbContext.SaveChanges();
    }
}
