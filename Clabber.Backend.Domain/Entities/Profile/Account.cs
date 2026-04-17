using Clabber.Backend.Domain.Entities.Profiles;
using Clabber.Backend.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace Clabber.Backend.Domain.Entities.Profile
{
    public class Account : IdentityUser<Guid>
    {
        public AccountRole Role { get; set; }

        public DateTime CreatedAt { get; set;  }

        public bool IsDeleted { get; set; }

        // Navigation properties

        public SponsorProfile? SponsorProfile { get; set; }

        public CreatorProfile? CreatorProfile { get; set; }
    }
}
