using Shared.EntityDtos.Insurances.InsuranceBenefit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts.Insurances
{
    public interface IInsuranceBenefitTypeService
    {
        Task<InsuranceBenefitTypeDto> AddBenefitType(AddInsuranceBenefitTypeDto benefitTypeDto);
        Task<List<InsuranceBenefitTypeDto>> GetBenefitTypes();
    }
}
