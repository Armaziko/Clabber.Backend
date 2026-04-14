using Clabber.Backend.Domain.Generics;

namespace Clabber.Backend.Domain.Entities
{
    public class CreatorMetricsHistory : BaseEntity
    {
        public CreatorMetricsHistory(Guid id) : base(id)
        {
        }

        public Guid ChannelId { get; set;  }

        public DateTime SnapshotDate { get; set; }

        public int ViewsMedian { get; set; }

        public int SharesMedian { get; set; }

        public decimal SaveRate { get; set; }

        // Navigation properties
        public SocialChannel SocialChannel { get; set; } = null!;
    }
}
