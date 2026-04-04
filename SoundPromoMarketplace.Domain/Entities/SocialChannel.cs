using SoundPromoMarketplace.Domain.Enums;
using SoundPromoMarketplace.Domain.Generics;

namespace SoundPromoMarketplace.Domain.Entities
{
    public class SocialChannel : AggregateRoot
    {
        public SocialChannel(Guid id) : base(id)
        {
        }

        public Guid CreatorId { get; set; }

        public SocialMediaPlatform Platform { get; set; }
        
        public string Handle { get; set; } = string.Empty;

        public string ExternalId { get; set; } = string.Empty;

        public int FollowerCount { get; set; }

        public decimal EngagementRate { get; set; }

        public DateTime LastScrapedAt { get; set; }
    }
}
