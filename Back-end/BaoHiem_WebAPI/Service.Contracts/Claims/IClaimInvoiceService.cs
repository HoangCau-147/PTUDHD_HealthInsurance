using Shared.EntityDtos.Claim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts.Claims
{
    public interface IClaimInvoiceService
    {
        Task<List<CLaimInvoiceDto>> GetAll();
    }
}
