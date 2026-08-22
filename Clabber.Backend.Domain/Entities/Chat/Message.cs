using Clabber.Backend.Domain.Generics;

namespace Clabber.Backend.Domain.Entities.Chat
{
    public class Message : BaseEntity
    {
        public Message(Guid id) : base(id)
        {
        }

        public Guid ChatId { get; set; }

        public Guid SenderAccountId { get; set; }

        public string Content { get; set; } = string.Empty;    

        public DateTime SentAt { get; set; }

        public bool IsRead { get; set; }
    }
}
