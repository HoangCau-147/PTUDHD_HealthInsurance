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
    public class ClaimRequestRepository : RepositoryBase<ClaimRequest>, IClaimRequestRepository
    {
        public ClaimRequestRepository(InsuranceDBContext insuranceDBContext) : base(insuranceDBContext)
        {
        }
        public bool AddRequest(ClaimRequest claimRequest)
        {
            return Create(claimRequest);
        }
        public async Task<List<ClaimRequest>> GetCustomerRequestByStatus(Guid CustomerId, string Status, bool trackChanges)
            => await FindByCondition(e => e.CustomerId == CustomerId && e.Status == Status, trackChanges)
            .Include(e => e.Contract)
            .Include(e => e.Customer).ToListAsync();
        public async Task<List<ClaimRequest>> GetCustomerRequest(Guid CustomerId, bool trackChanges)
            => await FindByCondition(e => e.CustomerId == CustomerId , trackChanges)
            .Include(e => e.Contract)
            .Include(e => e.Customer)
            .ToListAsync();
        public async Task<List<ClaimRequest>> GetRequestByStatus(string status, bool trackChanges)
            => await FindByCondition(e => e.Status == status, trackChanges)
            .Include(e => e.Contract)
            .Include(e => e.Customer)
            .ToListAsync();    
        public async Task<ClaimRequest> GetRequestById(Guid id, bool trackChanges)
            => await FindByCondition(e => e.Id == id, trackChanges)
            .Include(e => e.Contract)
            .Include(e => e.Customer)
            .SingleOrDefaultAsync();
    }
}
