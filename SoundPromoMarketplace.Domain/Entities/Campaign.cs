using SoundPromoMarketplace.Domain.Enums;
using SoundPromoMarketplace.Domain.Generics;

namespace SoundPromoMarketplace.Domain.Entities
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
    }
}
