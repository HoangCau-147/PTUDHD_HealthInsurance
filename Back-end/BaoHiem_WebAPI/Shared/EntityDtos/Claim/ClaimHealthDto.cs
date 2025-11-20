

namespace Shared.EntityDtos.Claim
{
    public class ClaimHealthDto
    {
        public Guid Id { get; set; }
        public string? ServiceName { get; set; }
        public int? CostOfATreatment { get; set; }
        public string? HospitalName { get; set; }
        public DateTime? UsedDate { get; set; }

    }
}
