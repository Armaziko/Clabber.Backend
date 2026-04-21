using Clabber.Backend.Domain.Entities.Campaign;
using Clabber.Backend.Domain.Entities.Profile;
using Clabber.Backend.Domain.Generics;

namespace Clabber.Backend.Domain.Entities.Profiles
{
    public class CreatorProfile : AggregateRoot
    {
        public CreatorProfile(Guid id) : base(id)
        {
        }

        public Guid AccountId { get; set; }

        public string Bio { get; set; } = string.Empty; 

        public string MainGenre { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;

        public decimal OverallRating { get; set; }

        public bool IsDeleted { get; set; }

        // Navigation properties
        public Account Account { get; set; } = null!;

        public ICollection<SocialChannel> SocialChannels { get; set; } = new List<SocialChannel>();
        public ICollection<Sponsorship> Sponsorships { get; set; } = new List<Sponsorship>();
        public ICollection<Friendship> SentFriendRequests { get; set; } = new List<Friendship>();
        public ICollection<Friendship> ReceivedFriendRequests { get; set; } = new List<Friendship>();
    }
}
