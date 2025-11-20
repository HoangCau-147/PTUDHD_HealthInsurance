using Entity.Models.InsuranceContractModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.InsuranceContractContracts
{
    public interface IContractInvoiceRepository
    {
        bool AddInvoice(ContractInvoice contractInvoice);
        Task<List<ContractInvoice>> GetInvoiceByContractId(Guid contractI, bool trackChanges);
        Task<List<ContractInvoice>> GetInvoiceByYear(int year, bool trackChanges);
    }
}
