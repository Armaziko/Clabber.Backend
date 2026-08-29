using Clabber.Backend.Domain.Enums;
using Clabber.Backend.Domain.Generics;

namespace Clabber.Backend.Domain.Entities.Profile
{
    public class Verification : BaseEntity
    {
        public Verification(Guid id) : base(id)
        {
        }

        public Guid AccountId { get; set; }
        public VerificationStatus Status { get; set; }
        public DateTime CreatedAt { get; set; } 
        public DateTime LastUpdatedAt { get; set; }

        // Navigation property
        public Account Account { get; set; } = default!;

        public bool IsVerified()
        {
            return Status == VerificationStatus.Verified;
        }
    }
}
