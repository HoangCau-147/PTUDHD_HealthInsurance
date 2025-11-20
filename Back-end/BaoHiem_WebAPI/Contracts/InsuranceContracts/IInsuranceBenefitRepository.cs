using Entity.Models.InsuranceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.InsuranceContracts
{
    public interface IInsuranceBenefitRepository
    {
        Task<InsuranceBenefit> GetById(int Id, bool trachChanges);
        bool AddBenefit(InsuranceBenefit benefit);
    }
}
