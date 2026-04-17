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
    }
}
