using Clabber.Backend.Domain.Enums;
using Clabber.Backend.Domain.Generics;

namespace Clabber.Backend.Domain.Entities
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

        // Navigation properties
        public CreatorProfile CreatorProfile { get; set; } = null!;
        public ICollection<Collaboration> Collaborations { get; set; }
        public ICollection<CreatorMetricsHistory> CreatorMetricsHistories { get; set; }

        public ICollection<PredictiveAnalysis> PredictiveAnalyses { get; set; }
    }
}
