using Entity.Models.Claim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.ClaimContracts
{
    public interface IClaimRequestRepository
    {
        Task<List<ClaimRequest>> GetRequestByStatus(string status, bool trackChanges);
        Task<List<ClaimRequest>> GetCustomerRequestByStatus(Guid CustomerId, string Status, bool trackChanges);
        bool AddRequest(ClaimRequest claimRequest);
        Task<List<ClaimRequest>> GetCustomerRequest(Guid CustomerId, bool trackChanges);
        Task<ClaimRequest> GetRequestById(Guid id, bool trackChanges);
    }
}
