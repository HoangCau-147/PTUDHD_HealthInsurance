using Shared.EntityDtos.Insurances;
using Shared.EntityDtos.Insurances.HealthCondition;

namespace Service.Contracts.Insurances
{
    public interface IHealthConditionService
    {
        Task<HealthConditionProductDto> GetById(int Id);
        Task<List<HealthConditionDto>> GetAll();
        Task<HealthConditionDto> AddCondtions(AddHealthConditionDto conditionDto);
    }
}
