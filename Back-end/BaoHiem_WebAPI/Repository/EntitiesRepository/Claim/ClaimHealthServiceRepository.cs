using Contracts.ClaimContracts;
using Entity.Models.Claim;
using Service.Contract.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EntitiesRepository.Claim
{
    public class ClaimHealthServiceRepository : RepositoryBase<ClaimHealthService>, IClaimHealthServiceRepository
    {
        public ClaimHealthServiceRepository(InsuranceDBContext insuranceDBContext) : base(insuranceDBContext)
        {
        }
    }
}
