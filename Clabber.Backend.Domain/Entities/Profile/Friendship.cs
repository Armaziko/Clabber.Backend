using Clabber.Backend.Domain.Enums;
using Clabber.Backend.Domain.Generics;

namespace Clabber.Backend.Domain.Entities.Profiles
{
    public class Friendship : BaseEntity
    {
        public Friendship(Guid id) : base(id)
        {
        }

        public Guid RequesterId { get; set; } // Represents an ID of a content creator's profile only.

        public Guid ReceiverId { get; set; } // Represents an ID of a content creator's profile only.

        public FriendshipStatus Status { get; set; }

        public DateTime CreatedAt { get; set; } 

        // Navigation properties
        public CreatorProfile RequesterCreator { get; set; } = default!;
        public CreatorProfile ReceiverCreator { get; set; } = default!;
    }
}
