using Clabber.Backend.Domain.Enums;
using Clabber.Backend.Domain.Generics;

namespace Clabber.Backend.Domain.Entities
{
    public class Campaign : AggregateRoot
    {
        public Campaign(Guid id) : base(id)
        {
        }

        public Guid BuyerId { get; set; }
        public Guid AudioTrackId { get; set; }
        public decimal BudgetTotal { get; set; }

        public CampaignStatus Status { get; set; }

        public DateTime StartDate { get; set; }

        // Navigation properties

        public BuyerProfile Buyer { get; set; } = null!;

        public AudioTrack AudioTrack { get; set; } = null!;

        public ICollection<Collaboration> Collaborations { get; set; } = null!;
    }
}
