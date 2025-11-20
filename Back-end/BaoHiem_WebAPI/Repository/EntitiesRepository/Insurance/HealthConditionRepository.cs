using Contracts;
using Contracts.InsuranceContracts;
using Entity.Models.InsuranceModels;
using Microsoft.EntityFrameworkCore;

namespace Repository.EntitiesRepository.Insurance
{
    public class HealthConditionRepository : RepositoryBase<HealthCondition>, IHealthConditionRepository
    {
        public HealthConditionRepository(InsuranceDBContext insuranceDBContext) : base(insuranceDBContext)
        {
        }

        public async Task<HealthCondition> GetByIdAsync(int Id, bool trackChanges)
        {
            return await FindByCondition(e => e.HealthConditionId == Id, trackChanges).SingleOrDefaultAsync();
        }
        public HealthCondition GetById(int Id, bool trackChanges)
        {
            return FindByCondition(e => e.HealthConditionId == Id, trackChanges).SingleOrDefault();
        }
        public async Task<List<HealthCondition>> GetAllAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).ToListAsync();
        }
        public bool Add(HealthCondition condition)
        {
            return Create(condition);
        }

        public async Task<HealthCondition> GetByGuidIdAsync(Guid Id, bool trackChanges)
        {
            return await FindByCondition(e => e.Id == Id, trackChanges).SingleOrDefaultAsync();
        }
    }
}
