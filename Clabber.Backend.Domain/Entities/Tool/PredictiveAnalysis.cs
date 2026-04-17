using Clabber.Backend.Domain.Entities.Media;
using Clabber.Backend.Domain.Entities.Profiles;
using Clabber.Backend.Domain.Generics;

namespace Clabber.Backend.Domain.Entities.Tool
{
    public class PredictiveAnalysis : BaseEntity
    {
        public PredictiveAnalysis(Guid id) : base(id)
        {
        }
        public Guid SponsorId { get; set; }
        public Guid ChannelId { get; set; }
        public Guid AudioTrackId { get; set; }
        public decimal NeuralVibeScore { get; set; }
        public decimal AlgorithmicProbability { get; set; }
        public string PredictedViewRange { get; set; } = string.Empty;
        public decimal SuggestedOptimalBid { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }

        // Navigation property
        public SponsorProfile? Sponsor { get; set; } = null!;
        public CreatorProfile? CreatorProfile { get; set; } = null!;
        public SocialChannel SocialChannel { get; set; } = null!;
        public UploadedMedia AudioTrack { get; set; } = null!;
    }
}
