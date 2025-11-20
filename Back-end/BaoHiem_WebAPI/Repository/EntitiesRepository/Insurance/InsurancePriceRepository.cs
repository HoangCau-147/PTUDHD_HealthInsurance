using Contracts.InsuranceContracts;
using Entity.Models.InsuranceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EntitiesRepository.Insurance
{
    public class InsurancePriceRepository : RepositoryBase<InsurancePrice>, IInsurancePriceRepository
    {
        public InsurancePriceRepository(InsuranceDBContext insuranceDBContext) : base(insuranceDBContext)
        {
        }
    }
}
