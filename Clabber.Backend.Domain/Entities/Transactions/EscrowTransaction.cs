using Clabber.Backend.Domain.Entities.Campaign;
using Clabber.Backend.Domain.Enums;
using Clabber.Backend.Domain.Generics;

namespace Clabber.Backend.Domain.Entities.Transactions
{
    public class EscrowTransaction : BaseEntity
    {
        public EscrowTransaction(Guid id) : base(id)
        {
        }

        public Guid SponsorshipId { get; set; }
        public decimal Amount { get; set; }
        public string Currency {  get; set; } = string.Empty;
        public EscrowTransactionType Type { get; set; }
        public string ProcessingProvider { get; set; } = string.Empty;
        public string ProviderTransactionId { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }

        // Navigation properties
        public Sponsorship Sponsorship { get; set; } = default!;
    }
}
