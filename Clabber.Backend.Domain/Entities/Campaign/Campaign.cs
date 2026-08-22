using Clabber.Backend.Domain.Entities.Profiles;
using Clabber.Backend.Domain.Enums;
using Clabber.Backend.Domain.Generics;

namespace Clabber.Backend.Domain.Entities.Campaign
{
    public class Campaign : AggregateRoot
    {
        public Campaign(Guid id) : base(id)
        {
        }

        public Guid OwnerSponsorId { get; set; }
        public Guid PromotedProductId { get; set; }
        public decimal BudgetTotal { get; set; }
        public CampaignType Type { get; set; }
        public CampaignStatus Status { get; set; }
        public DateTime StartDate { get; set; }

        // Navigation properties
        public SponsorProfile OwnnerSponsor { get; set; } = null!;
        public PromotedProduct PromotedProduct { get; set; } = default!;
        public ICollection<Sponsorship> Sponsorships { get; set; } = null!;
    }
}
