using Clabber.Backend.Domain.Enums;
using Clabber.Backend.Domain.Generics;

namespace Clabber.Backend.Domain.Entities.Legal
{
    public class Deliverables : BaseEntity
    {
        public Deliverables(Guid id) : base(id)
        {
        }

        public Guid SponsorshipId { get; set; }
        public string S3Url { get; set; } = string.Empty;
        public DeliverablesStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
