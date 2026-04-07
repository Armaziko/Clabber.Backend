using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoundPromoMarketplace.Domain.Entities;

namespace SoundPromoMarketplace.Infrastructure.Persistence.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(account => account.Id);

            builder.HasIndex(acc => acc.Email).IsUnique();

            builder.Property(acc => acc.Email)
                .IsRequired()
                .HasMaxLength(256);

            builder.HasOne(acc => acc.BuyerProfile)
                .WithOne(bp => bp.Account)
                .HasForeignKey<BuyerProfile>(bp => bp.AccountId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(acc => acc.CreatorProfile)
                .WithOne(c => c.Account)
                .HasForeignKey<CreatorProfile>(c => c.AccountId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasQueryFilter(a => !a.IsDeleted);
        }
    }
}
