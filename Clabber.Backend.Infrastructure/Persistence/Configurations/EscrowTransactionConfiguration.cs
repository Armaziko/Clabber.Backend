using Clabber.Backend.Domain.Entities.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clabber.Backend.Infrastructure.Persistence.Configurations
{
    public class EscrowTransactionConfiguration : IEntityTypeConfiguration<EscrowTransaction>
    {
        public void Configure(EntityTypeBuilder<EscrowTransaction> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Amount).HasPrecision(18,2).IsRequired();
            builder.Property(x => x.Currency).IsRequired();
            builder.Property(x => x.Type).IsRequired();
            builder.Property(x => x.ProcessingProvider).IsRequired();

            builder.Property(x => x.ProviderTransactionId).IsRequired();
            builder.Property(x => x.CreatedAt).IsRequired();
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
