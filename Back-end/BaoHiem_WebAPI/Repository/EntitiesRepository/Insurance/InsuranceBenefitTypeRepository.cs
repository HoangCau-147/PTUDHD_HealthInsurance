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
    public class InsuranceBenefitTypeRepository : RepositoryBase<InsuranceBenefitType>, IInsuranceBenefitTypeRepository
    {
        public InsuranceBenefitTypeRepository(InsuranceDBContext insuranceDBContext) : base(insuranceDBContext)
        {
        }
        public bool AddType(InsuranceBenefitType insuranceDiseaseType) => Create(insuranceDiseaseType);
        public async Task<InsuranceBenefitType> GetByIdAsync(int Id, bool trackChanges) =>
            await FindByCondition(e => e.BenefitTypeId == Id, trackChanges).Include(e => e.Benefits).SingleOrDefaultAsync();
        public async Task<List<InsuranceBenefitType>> GetAll(bool trackChanges) =>
            await FindAll(trackChanges).Include(e => e.Benefits).ToListAsync();

        public InsuranceBenefitType GetById(int Id, bool trackChanges)
        {
            return FindByCondition(e => e.BenefitTypeId == Id, trackChanges).Include(e => e.Benefits).SingleOrDefault();
        }
    }
}
