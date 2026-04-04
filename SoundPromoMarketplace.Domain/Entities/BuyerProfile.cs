using SoundPromoMarketplace.Domain.Generics;

namespace SoundPromoMarketplace.Domain.Entities
{
    public class BuyerProfile : AggregateRoot
    {
        public BuyerProfile(Guid id) : base(id)
        {
        }

        public Guid AccountId { get; set; }

        public string OrganizationName { get; set; } = string.Empty;

        public string Industry { get; set; } = string.Empty;
    }
}
