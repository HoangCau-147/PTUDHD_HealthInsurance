using Shared.EntityDtos.Insurances.InsuranceProgram;
using Shared.EntityDtos.Insurances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts.Insurances
{
    public interface IInsuranceProgramService
    {
        Task<InsuranceProgramDto> AddPrograms(AddInsuranceProgramDto programDto);
        Task<List<InsuranceProgramDto>> GetPrograms(bool trackChange);
    }
}
