using AutoMapper;
using Contracts;
using Entity.Exceptions;
using Entity.Models.InsuranceModels;
using Service.Contracts.Insurances;
using Shared.EntityDtos.Insurances;
using Shared.EntityDtos.Insurances.InsuranceProgram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Insurances
{
    public class InsuranceProgramService : IInsuranceProgramService
    {
        private readonly IRepositoryManager _repositoryManager; 
        private readonly IMapper _mapper;
        public InsuranceProgramService(IRepositoryManager repositoryManager, IMapper mapper) 
        {
            this._repositoryManager = repositoryManager;
            this._mapper = mapper;
        }
        public async Task<List<InsuranceProgramDto>> GetPrograms(bool trackChange)
        {
            var programs = await _repositoryManager.InsurancePrograms.GetAllAsync(trackChange);
            return _mapper.Map<List<InsuranceProgramDto>>(programs);
        }
        public async Task<InsuranceProgramDto> AddPrograms(AddInsuranceProgramDto programDto)
        {
            var program = _mapper.Map<InsuranceProgram>(programDto);
            program.NormalizedName = program.Name.ToUpper();
            var result = _repositoryManager.InsurancePrograms.Add(program);
            if (!result)
            {
                throw new ReturnBadRequestException($"Program is added unscessfully");
            }
            await _repositoryManager.SaveAsync();
            var programReturn = _mapper.Map<InsuranceProgramDto>(program);
            return programReturn;
        }
    }
}
