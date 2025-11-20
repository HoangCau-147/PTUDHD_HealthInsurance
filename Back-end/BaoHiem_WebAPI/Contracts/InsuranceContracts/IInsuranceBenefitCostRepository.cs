using Entity.Models.InsuranceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.InsuranceContracts
{
    public interface IInsuranceBenefitCostRepository
    {
        Task<InsuranceBenefitCost> GetBenefitCost(Guid ProgramId, Guid ProductId, Guid BenefitId, bool trackChanges);
    }
}
