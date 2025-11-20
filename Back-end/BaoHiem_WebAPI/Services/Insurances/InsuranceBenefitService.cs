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
    public class InsuranceBenefitService : IInsuranceBenefitService
    {
        private readonly IRepositoryManager _repositoryManager;
        public InsuranceBenefitService(IRepositoryManager repositoryManager) 
        { 
            this._repositoryManager = repositoryManager;
        }
        public async Task AddBenefit(int benefitTypeId, AddInsuranceBenefitDto benefitDto)
        {
            var benefitType = await _repositoryManager.InsuranceBenefitType.GetByIdAsync(benefitTypeId, false);
            if (benefitType == null)
                throw new ReturnNotFoundException($"Benefit type with id: {benefitTypeId} dose not exist");
            var newBenefit = new InsuranceBenefit
            {
                Id = Guid.NewGuid(),
                Description = benefitDto.Description,
                BenefitTypeId = benefitType.Id,
                BenefitName = benefitDto.BenefitName
            };
            if(!_repositoryManager.InsuranceBenefit.AddBenefit(newBenefit))
            {
                throw new ReturnBadRequestException("Benefit was created unsuccessfully");
            }
            await _repositoryManager.SaveAsync();
        }
        
    }
}
