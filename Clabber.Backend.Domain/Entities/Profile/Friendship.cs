using Clabber.Backend.Domain.Enums;
using Clabber.Backend.Domain.Generics;

namespace Clabber.Backend.Domain.Entities.Profiles
{
    public class Friendship : BaseEntity
    {
        public Friendship(Guid id) : base(id)
        {
        }

        public Guid RequesterId { get; set; }

        public Guid ReceiverId { get; set; }

        public FriendshipStatus Status { get; set; }

        public DateTime CreatedAt { get; set; } 

        public bool IsDeleted { get; set; }
    }
}
