using Shared.EntityDtos.Claim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts.Claims
{
    public interface IClaimPaymentService
    {
        Task AddPayment(CreateClaimPaymentDto createPaymentDto);
        Task<List<ClaimPaymentDto>> GetAll();
        Task UpdateStatus(Guid paymentId, string EmpEmail);
        Task<List<ReportClaimRequetDto>> GetReport(int CustomerId);
    }
}
