using Entity.Models.Claim;
using Shared.EntityDtos.Claim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts.Claims 
{
    public interface IClaimRequestService
    {
        Task DenyRequest(Guid Id);
        Task CreateRequest(CreateClaimRequestDto requestDto);
        Task<List<ClaimRequestDto>> GetClaimRequestOfCustomer(int cusotmerId, RequestStatus status);
        Task<List<ClaimRequestDto>> GetClaimRequestByStatus(RequestStatus Status);
    }
}
