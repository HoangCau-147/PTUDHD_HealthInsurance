using Entity.Models.Claim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.ClaimContracts
{
    public interface IClaimInvoiceRepository
    {
        bool AddInvoice(ClaimInvoice invoice);
        Task<List<ClaimInvoice>> GetAll(bool trackChange);
        Task<List<ClaimInvoice>> GetByYear(int year, bool trackChange);
    }
}
