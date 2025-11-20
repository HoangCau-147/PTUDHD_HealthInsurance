using Entity.Models.InsuranceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.InsuranceContracts
{
    public interface IInsuranceProductRepository
    {
        Task<InsuranceProduct> GetById(int id, bool trackChanges);
        Task<List<InsuranceProduct>> GetAll(bool trackChanges);

        bool Add(InsuranceProduct insuranceProduct);
    }
}
