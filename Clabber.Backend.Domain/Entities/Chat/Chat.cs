using Clabber.Backend.Domain.Generics;

namespace Clabber.Backend.Domain.Entities.Chat
{
    public class Chat : AggregateRoot
    {
        public Chat(Guid id) : base(id)
        {
        }

        public bool IsGroup { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
