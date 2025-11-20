using Contracts.InsuranceContracts;
using Entity.Models.InsuranceModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EntitiesRepository.Insurance
{
    public class InsuranceBenefitCostRepository : RepositoryBase<InsuranceBenefitCost>, IInsuranceBenefitCostRepository
    {
        public InsuranceBenefitCostRepository(InsuranceDBContext insuranceDBContext) : base(insuranceDBContext)
        {
        }
        public async Task<InsuranceBenefitCost> GetBenefitCost(Guid ProgramId, Guid ProductId, Guid BenefitId, bool trackChanges)
        {
            return await FindByCondition(e => e.PolicyId == ProductId && e.BenefitId == BenefitId && e.ProgramId == ProgramId, trackChanges)
                .SingleOrDefaultAsync();
        }
    }
}
