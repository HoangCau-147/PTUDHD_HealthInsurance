using AutoMapper;
using Contracts;
using Entity.Exceptions;
using Entity.Models.InsuranceModels;
using Service.Contracts.Insurances;
using Shared.EntityDtos.Insurances.InsuranceBenefit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Insurances
{
    public class InsuranceBenefitTypeService : IInsuranceBenefitTypeService
    {
        private readonly IRepositoryManager _repositoryManager; 
        private readonly IMapper _mapper;   
        public InsuranceBenefitTypeService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            this._mapper = mapper;
            this._repositoryManager = repositoryManager;
        }

        public async Task<InsuranceBenefitTypeDto> AddBenefitType(AddInsuranceBenefitTypeDto benefitTypeDto)
        {
            var benefitType = _mapper.Map<InsuranceBenefitType>(benefitTypeDto);

            _repositoryManager.InsuranceBenefitType.AddType(benefitType);

            await _repositoryManager.SaveAsync();
            var returnType = _mapper.Map<InsuranceBenefitTypeDto>(benefitType);
            return returnType;
        }
        public async Task<List<InsuranceBenefitTypeDto>> GetBenefitTypes()
        {
            var benefitTypes = await _repositoryManager.InsuranceBenefitType.GetAll(false);
            if(benefitTypes.Count == 0)
            {
                throw new ReturnNotFoundException("Benefit type not found");
            }
            var returnBenefitTypes = _mapper.Map<List<InsuranceBenefitTypeDto>>(benefitTypes);
            return returnBenefitTypes;
        }
    }
}
