using Contracts.ClaimContracts;
using Entity.Models.Claim;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EntitiesRepository.Claim
{
    public class ClaimInvoiceRepository : RepositoryBase<ClaimInvoice>, IClaimInvoiceRepository
    {
        public ClaimInvoiceRepository(InsuranceDBContext insuranceDBContext) : base(insuranceDBContext)
        {
        }
        public bool AddInvoice(ClaimInvoice invoice) => Create(invoice);
        public async Task<List<ClaimInvoice>> GetAll(bool trackChange)
            => await FindAll(trackChange).ToListAsync();
        public async Task<List<ClaimInvoice>> GetByYear(int year, bool trackChange)
            => await FindByCondition(e => e.CreatedDate.Year == year, trackChange).ToListAsync();
    }
}
