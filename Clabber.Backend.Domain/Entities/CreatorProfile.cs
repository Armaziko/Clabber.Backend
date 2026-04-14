using Clabber.Backend.Domain.Generics;

namespace Clabber.Backend.Domain.Entities
{
    public class CreatorProfile : AggregateRoot
    {
        public CreatorProfile(Guid id) : base(id)
        {
        }

        public Guid AccountId { get; set; }

        public string DisplayName { get; set; } = string.Empty;

        public string Bio { get; set; } = string.Empty; 

        public string MainGenre { get; set; } = string.Empty;

        public string CountryCode { get; set; } = string.Empty;

        public decimal OverallRating { get; set; }

        // Navigation properties
        public Account Account { get; set; } = null!;

        public ICollection<SocialChannel> SocialChannels { get; set; } = null!;

        public ICollection<Collaboration> Collaborations { get; set; } = null!;
    }
}
