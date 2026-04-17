using Clabber.Backend.Domain.Generics;

namespace Clabber.Backend.Domain.Entities.Chat
{
    public class ChatParticipant : BaseEntity
    {
        public ChatParticipant(Guid id) : base(id)
        {
        }
        
        public Guid ChatId { get; set; }
        public Guid AccountId { get; set; }

        public bool IsDeleted { get; set; }
    }
}
