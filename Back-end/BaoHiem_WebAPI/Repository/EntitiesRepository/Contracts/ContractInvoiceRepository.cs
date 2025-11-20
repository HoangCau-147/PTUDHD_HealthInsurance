using Contracts.InsuranceContractContracts;
using Entity.Models.Claim;
using Entity.Models.InsuranceContractModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EntitiesRepository.Contracts
{
    public class ContractInvoiceRepository : RepositoryBase<ContractInvoice>, IContractInvoiceRepository
    {
        public ContractInvoiceRepository(InsuranceDBContext insuranceDBContext) : base(insuranceDBContext)
        {
        }
        public bool AddInvoice(ContractInvoice contractInvoice)
        {
            return Create(contractInvoice);
        }
        public async Task<List<ContractInvoice>> GetInvoiceByContractId(Guid contractId, bool trackChanges)
        {
            return await FindByCondition(e => e.ContractID == contractId, trackChanges).ToListAsync();
        }
        public async Task<List<ContractInvoice>> GetInvoiceByYear(int year, bool trackChanges)
        {
            return await FindByCondition(e => e.CreatedDate.Value.Year == year, trackChanges).ToListAsync();
        }
    }
}
