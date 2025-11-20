using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.EntityDtos.Claim
{
    public class CreateClaimPaymentDto
    {
        public Guid RequestId { get; set; }
        public List<CreateClaimHeathDto> ClaimHeaths { get; set; }
    }
}
