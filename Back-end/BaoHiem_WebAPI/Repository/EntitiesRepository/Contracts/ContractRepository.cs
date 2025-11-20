using Contracts.InsuranceContractContracts;
using Entity.Models.InsuranceContractModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EntitiesRepository.Contracts
{
    public class ContractRepository : RepositoryBase<Contract>, IContractRepository
    {
        public ContractRepository(InsuranceDBContext insuranceDBContext) : base(insuranceDBContext)
        {
        }
        public bool CreateContract(Contract contract)
        {
            return Create(contract);
        }
        public async Task<List<Contract>> GetAll(bool trackChanges) =>
            await FindAll(trackChanges)
            .Include(e => e.InsuranceProduct)
            .Include(e => e.InsuranceProgram)
            .Include(e => e.ContractHealthConditions)
            .Include(e => e.Customer)
            .Include(e => e.Employee)
            .ToListAsync();
        public async Task<List<Contract>> GetByProductId(Guid productId, bool trackChanges) =>
            await FindByCondition(e => e.InsuranceProductId == productId, trackChanges)
            .Include(e => e.InsuranceProduct)
            .Include(e => e.InsuranceProgram)
            .Include(e => e.ContractHealthConditions)
            .Include(e => e.Customer)
            .Include(e => e.Employee)
            .ToListAsync();
        public async Task<List<Contract>> GetContractsByStatus(ContractStatus status, bool trackChanges) =>
            await FindByCondition(e => e.Status == status.ToString(), trackChanges)
            .Include(e => e.InsuranceProduct)
            .Include(e => e.InsuranceProgram)
            .Include(e => e.ContractHealthConditions)
            .Include(e => e.Customer)
            .Include(e => e.Employee)
            .ToListAsync();
        public async Task<Contract> GetContractsById(Guid Id, bool trackChanges) =>
            await FindByCondition(e => e.ContractId == Id, trackChanges)
            .Include(e => e.InsuranceProduct)
            .Include(e => e.InsuranceProgram)
            .Include(e => e.ContractHealthConditions)
            .Include(e => e.Customer)
            .Include(e => e.Employee)
            .SingleOrDefaultAsync();
        public async Task<Contract> GetContractsByPrimaryId(Guid Id, bool trackChanges) =>
            await FindByCondition(e => e.Id == Id, trackChanges)
            .Include(e => e.InsuranceProduct)
            .Include(e => e.InsuranceProgram)
            .Include(e => e.ContractHealthConditions)
            .Include(e => e.Customer)
            .Include(e => e.Employee)
            .SingleOrDefaultAsync();
        public async Task<List<Contract>> GetContractsByCustomerIdAndStatus(Guid customerId, string status, bool trackChanges) =>
            await FindByCondition(e => e.CustomerID == customerId && e.Status == status, trackChanges)
            .Include(e => e.InsuranceProduct)
            .Include(e => e.InsuranceProgram)
            .Include(e => e.ContractHealthConditions)
            .Include(e => e.Customer)
            .Include(e => e.Employee)
            .ToListAsync();
        public async Task<List<Contract>> GetContractsByCustomerIdAndStatuses(List<string> statuses, bool trackchange)
            => await FindByCondition(e => statuses.Contains(e.Status), trackchange)
            .ToListAsync();
    }
}
