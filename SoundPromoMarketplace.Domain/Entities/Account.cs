using SoundPromoMarketplace.Domain.Enums;
using SoundPromoMarketplace.Domain.Generics;

namespace SoundPromoMarketplace.Domain.Entities
{
    public class Account : AggregateRoot
    {
        public Account(Guid id) : base(id)
        {
        }

        public string Email { get; private set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public AccountRole Role { get; set; }

        public DateTime CreatedAt { get; set;  }

        public bool IsDeleted { get; set; }

        // Navigation properties

        public BuyerProfile? BuyerProfile { get; set; }

        public CreatorProfile? CreatorProfile { get; set; }
    }
}
