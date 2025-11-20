using Entity.Models.InsuranceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.InsuranceContracts
{
    public interface IInsuranceProgramRepository
    {
        Task<InsuranceProgram> GetById(int id);
        bool Add(InsuranceProgram program);
        Task<List<InsuranceProgram>> GetAllAsync( bool trackChanges);
        Task<InsuranceProgram> GetByGuidId(Guid id, bool trackChanges);
    }
}
