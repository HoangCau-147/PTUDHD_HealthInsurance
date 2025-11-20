using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.EntityDtos.Insurances.InsuranceProduct
{
    public class UpdateProductDto
    {
        public int ProductId { get; set; }
        public string? PolicyName { get; set; }
        public string? InsuredParty { get; set; }
        public string? TerritorialScope { get; set; }
        public string? ParticipationProcedure { get; set; }
        public string? FeeGuarantee { get; set; }
        public string? Commitment { get; set; }
        public string? ShortDescription { get; set; }
        public string? ImageUrl { get; set; }
    }
}
