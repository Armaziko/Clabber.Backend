using Clabber.Backend.Domain.Entities.Campaign;
using Clabber.Backend.Domain.Generics;

namespace Clabber.Backend.Domain.Entities.Legal
{
    public class LegalLicenses : BaseEntity
    {
        public LegalLicenses(Guid id) : base(id)
        {
        }

        public Guid SponsorshipId { get; set; }
        public string LicenseText { get; set; } = string.Empty;
        public string DigitalSignature { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }

        // Navigation property

        public Sponsorship Sponsorship { get; set; } = default!;
    }
}
