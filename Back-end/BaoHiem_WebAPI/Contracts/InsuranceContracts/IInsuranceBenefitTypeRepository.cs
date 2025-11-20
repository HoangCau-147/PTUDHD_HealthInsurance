using Entity.Models.InsuranceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.InsuranceContracts
{
    public interface IInsuranceBenefitTypeRepository
    {
        bool AddType(InsuranceBenefitType insuranceDiseaseType);
        Task<List<InsuranceBenefitType>> GetAll(bool trackChanges);
        Task<InsuranceBenefitType> GetByIdAsync(int Id, bool trackChanges);
    }
}
