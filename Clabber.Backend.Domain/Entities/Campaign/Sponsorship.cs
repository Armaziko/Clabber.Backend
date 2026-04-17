using Clabber.Backend.Domain.Entities.Profiles;
using Clabber.Backend.Domain.Enums;
using Clabber.Backend.Domain.Generics;

namespace Clabber.Backend.Domain.Entities.Campaign
{
    public class Sponsorship : BaseEntity
    {
        public Sponsorship(Guid id) : base(id)
        {
        }

        public Guid CampaignId { get; set; }
        public Guid CreatorId { get; set; }
        public Guid ChannelId { get; set; }
        public decimal AgreedPrice { get; set; }
        public CollaborationStatus Status { get; set; } 
        public string TrackingLink { get; set; } = string.Empty;
        public decimal MilestoneBonus { get; set; }
        public int TargetMetricGoal { get; set; }
        public int ActualMetricAchieved { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }

        // Navigation properties
        public Campaign Campaign { get; set; } = null!;

        public SocialChannel SocialChannel { get; set; } = null!;
        
        public CreatorProfile CreatorProfile { get; set; } = null!;
    }
}
