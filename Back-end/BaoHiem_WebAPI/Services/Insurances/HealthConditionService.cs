using AutoMapper;
using Contracts;
using Entity.Exceptions;
using Entity.Models.InsuranceModels;
using Service.Contracts.Insurances;
using Shared.EntityDtos.Insurances.HealthCondition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Insurances
{
    public class HealthConditionService : IHealthConditionService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        public HealthConditionService(IRepositoryManager repositoryManager, IMapper mapper) 
        { 
            this._repository = repositoryManager;
            this._mapper = mapper;
        }
        public async Task<HealthConditionProductDto> GetById(int Id)
        {
            var condition = await _repository.HealthConditions.GetByIdAsync(Id, false);
            return _mapper.Map<HealthConditionProductDto>(condition);
        }
        public async Task<List<HealthConditionDto>> GetAll()
        {
            var conditions = await _repository.HealthConditions.GetAllAsync(false);
            if (conditions.Count == 0)
                throw new Exception();
            var conditionReturn = _mapper.Map<List<HealthConditionDto>>(conditions);
            return conditionReturn;
        }
        public async Task<HealthConditionDto> AddCondtions(AddHealthConditionDto conditionDto)
        {
            var condition = _mapper.Map<HealthCondition>(conditionDto);
            var result = _repository.HealthConditions.Add(condition);
            if (!result)
                throw new ReturnBadRequestException("Condition is added unsuccessfully");
            await _repository.SaveAsync();
            var conditionReturn = _mapper.Map<HealthConditionDto>(condition);
            return conditionReturn;
        }
    }
}
