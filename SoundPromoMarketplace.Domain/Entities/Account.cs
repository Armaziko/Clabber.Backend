using Microsoft.AspNetCore.Identity;
using SoundPromoMarketplace.Domain.Enums;

namespace SoundPromoMarketplace.Domain.Entities
{
    public class Account : IdentityUser<Guid>
    {
        public AccountRole Role { get; set; }

        public DateTime CreatedAt { get; set;  }

        public bool IsDeleted { get; set; }

        // Navigation properties

        public BuyerProfile? BuyerProfile { get; set; }

        public CreatorProfile? CreatorProfile { get; set; }
    }
}
