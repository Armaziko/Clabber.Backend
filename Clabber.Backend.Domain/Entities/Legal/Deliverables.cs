using Clabber.Backend.Domain.Entities.Campaign;
using Clabber.Backend.Domain.Enums;
using Clabber.Backend.Domain.Generics;

namespace Clabber.Backend.Domain.Entities.Legal
{
    /// <summary>
    /// Entity that represents the proof of creator's end of bargain.
    /// </summary>
    public class Deliverables : BaseEntity
    {
        public Deliverables(Guid id) : base(id)
        {
        }

        public Guid SponsorshipId { get; set; }
        public string S3Url { get; set; } = string.Empty;
        public DeliverablesStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties

        public Sponsorship Sponsorship { get; set; } = default!;
    }
}
