using Shared.EntityDtos.Contract;
using Shared.EntityDtos.Insurances.HealthCondition;
using Shared.EntityDtos.Insurances.InsuranceBenefit;
using Shared.EntityDtos.Insurances.InsuranceProgram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.EntityDtos.Insurances.InsuranceProduct
{
    public class InsuranceProductDto
    {
        public int ProductId { get; set; }
        public string? PolicyName { get; set; }
        public string? InsuredParty { get; set; }
        public string? TerritorialScope { get; set; }
        public string? ParticipationProcedure { get; set; }
        public string? FeeGuarantee { get; set; }
        public string? Commitment { get; set; }
        public int? TotalQuantitySold { get; set; }
        public string? ShortDescription { get; set; }
        public string? ImageUrl { get; set; }
        public List<HealthConditionProductDto> Conditions { get; set; }
        public List<InsuranceBenefitTypeProductDto> benefitType { get; set; }
        public List<ProgramPriceDto> ProgramPrice { get; set; }
    }
}
