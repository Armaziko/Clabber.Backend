using Clabber.Backend.Domain.Entities.Media;
using Clabber.Backend.Domain.Entities.Profile;
using Clabber.Backend.Domain.Entities.Tool;
using Clabber.Backend.Domain.Generics;

namespace Clabber.Backend.Domain.Entities.Profiles
{
    public class SponsorProfile : AggregateRoot
    {
        public SponsorProfile(Guid id) : base(id)
        {
        }

        public Guid AccountId { get; set; }

        public string OrganizationName { get; set; } = string.Empty;

        public bool IsDeleted { get; set; }
        // Navigation properties

        public Account Account { get; set; } = null!;

        public ICollection<Campaign> Campaigns { get; set; } = null!;

        public ICollection<UploadedMedia> AudioTracks { get; set; } = null!;

        public ICollection<PredictiveAnalysis> PredictiveAnalyses { get; set; } = null!; 
    }
}
