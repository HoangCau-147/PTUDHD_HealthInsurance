using Entity.Models.InsuranceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.InsuranceContracts
{
    public interface IHealthConditionRepository
    {
        Task<HealthCondition> GetByIdAsync(int Id, bool trackChanges);
        Task<HealthCondition> GetByGuidIdAsync(Guid Id, bool trackChanges);
        HealthCondition GetById(int Id, bool trackChanges);
        Task<List<HealthCondition>> GetAllAsync(bool trackChanges);
        bool Add(HealthCondition condition);
    }
}
