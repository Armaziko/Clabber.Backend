using Clabber.Backend.Domain.Entities.Media;
using Clabber.Backend.Domain.Entities.Profiles;
using Clabber.Backend.Domain.Generics;

namespace Clabber.Backend.Domain.Entities.Campaign
{
    public class PromotedProduct : AggregateRoot
    {
        public PromotedProduct(Guid id) : base(id)
        {
        }
        public Guid SponsorId { get; set; }
        public Guid MediaCollectionId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Category {  get; set; } = string.Empty;
        public bool IsDigitial { get; set; }
        public string? ExternalUrl { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; }
        public bool IsDeleted { get; set; }

        // Navigation properties
        public SponsorProfile Profile { get; set; } = default!;
        public MediaCollection MediaCollection { get; set; } = default!;
    }
}
