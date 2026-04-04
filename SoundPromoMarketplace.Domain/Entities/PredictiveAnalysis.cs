using SoundPromoMarketplace.Domain.Generics;

namespace SoundPromoMarketplace.Domain.Entities
{
    public class PredictiveAnalysis : BaseEntity
    {
        public PredictiveAnalysis(Guid id) : base(id)
        {
        }

        public Guid BuyerId { get; set; }

        public Guid ChannelId { get; set; }

        public Guid AudioTrackId { get; set; }

        public decimal NeuralVibeScore { get; set; }

        public decimal AlgorithmicProbability { get; set; }

        public string PredictedViewRange { get; set; } = string.Empty;

        public decimal SuggestedOptimalBid { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
