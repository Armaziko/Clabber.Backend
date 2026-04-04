using SoundPromoMarketplace.Domain.Generics;

namespace SoundPromoMarketplace.Domain.Entities
{
    public class AudioTrack : AggregateRoot
    {
        public AudioTrack(Guid id) : base(id)
        {
        }

        public Guid BuyerId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string S3Url { get; set; } = string.Empty;

        public int Bpm { get ; set; }

        public string Genre { get; set; } = string.Empty;

        public int DurationSeconds { get; set; }
    }
}
