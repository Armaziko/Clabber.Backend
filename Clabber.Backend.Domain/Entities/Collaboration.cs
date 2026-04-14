using Clabber.Backend.Domain.Enums;
using Clabber.Backend.Domain.Generics;

namespace Clabber.Backend.Domain.Entities
{
    public class Collaboration : BaseEntity
    {
        public Collaboration(Guid id) : base(id)
        {
        }

        public Guid CampaignId { get; set; }

        public Guid CreatorId { get; set; }

        public Guid ChannelId { get; set; }

        public decimal AgreedPrice { get; set; }

        public CollaborationStatus Status { get; set; } 

        public string TrackingLink { get; set; } = string.Empty;

        // Navigation properties
        public Campaign Campaign { get; set; } = null!;

        public SocialChannel SocialChannel { get; set; } = null!;
        
        public CreatorProfile CreatorProfile { get; set; } = null!;
    }
}
