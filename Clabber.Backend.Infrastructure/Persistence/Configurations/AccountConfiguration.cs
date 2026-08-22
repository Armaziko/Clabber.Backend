using Clabber.Backend.Domain.Entities.Profile;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clabber.Backend.Infrastructure.Persistence.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasIndex(acc => acc.Email).IsUnique();

            builder.HasIndex(acc => acc.DisplayName).IsUnique();

            builder.Property(acc => acc.Email)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(acc => acc.DisplayName)
                .IsRequired()
                .HasMaxLength(64);

            builder.HasQueryFilter(a => !a.IsDeleted);
        }
    }
}
