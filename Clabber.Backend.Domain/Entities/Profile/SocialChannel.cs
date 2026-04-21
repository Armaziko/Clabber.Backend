using Clabber.Backend.Domain.Entities.Campaign;
using Clabber.Backend.Domain.Entities.Media;
using Clabber.Backend.Domain.Entities.Tool;
using Clabber.Backend.Domain.Enums;
using Clabber.Backend.Domain.Generics;

namespace Clabber.Backend.Domain.Entities.Profiles
{
    public class SocialChannel : AggregateRoot
    {
        public SocialChannel(Guid id) : base(id)
        {
        }
        public Guid CreatorId { get; set; }
        public Guid ProfilePictureId { get; set; }
        public SocialMediaPlatform Platform { get; set; }
        public string Handle { get; set; } = string.Empty;
        public string ExternalId { get; set; } = string.Empty;
        public int FollowerCount { get; set; } 
        public string GeneralGenre { get; set; } = string.Empty; 
        public decimal EngagementRate { get; set; }
        public DateTime LastScrapedAt { get; set; }

        public bool IsDeleted { get; set; }

        // Navigation properties
        public CreatorProfile CreatorProfile { get; set; } = default!;
        public ProfilePicture ProfilePicture { get; set; } = default!;
        public ICollection<Sponsorship> Sponsorships { get; set; } = default!;
        public ICollection<CreatorMetricsHistory> CreatorMetricsHistories { get; set; } = default!;

        public ICollection<PredictiveAnalysis> PredictiveAnalyses { get; set; } = default!;
    }
}
