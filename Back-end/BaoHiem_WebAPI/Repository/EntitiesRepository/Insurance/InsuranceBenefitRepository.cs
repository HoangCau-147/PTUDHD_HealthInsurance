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
    public class InsuranceBenefitRepository : RepositoryBase<InsuranceBenefit>, IInsuranceBenefitRepository
    {
        public InsuranceBenefitRepository(InsuranceDBContext insuranceDBContext) : base(insuranceDBContext)
        {
        }

        public async Task<InsuranceBenefit> GetById(int Id, bool trachChanges)
        {
            return  await FindByCondition(e => e.BenefitId == Id, trachChanges).SingleOrDefaultAsync();
        }
        public bool AddBenefit(InsuranceBenefit benefit) => Create(benefit);
    }
}
