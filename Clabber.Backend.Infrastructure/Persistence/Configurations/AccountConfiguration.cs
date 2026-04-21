using Clabber.Backend.Domain.Entities.Media;
using Clabber.Backend.Domain.Entities.Profile;
using Clabber.Backend.Domain.Entities.Profiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clabber.Backend.Infrastructure.Persistence.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            // Identity already creates and identifies a primary key, so no need for .HasKey() stuff

            builder.HasIndex(acc => acc.Email).IsUnique();

            builder.HasIndex(acc => acc.DisplayName).IsUnique();

            builder.Property(acc => acc.Email)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(acc => acc.DisplayName)
                .IsRequired()
                .HasMaxLength(64);

            builder.HasOne(acc => acc.SponsorProfile)
                .WithOne(sp => sp.Account)
                .HasForeignKey<SponsorProfile>(sp => sp.AccountId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(acc => acc.CreatorProfile)
                .WithOne(c => c.Account)
                .HasForeignKey<CreatorProfile>(c => c.AccountId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(acc => acc.UploadedMedias)
                .WithOne(up => up.Account)
                .HasForeignKey(up => up.AccountId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(acc => acc.Verification)
                .WithOne(v => v.Account)
                .HasForeignKey<Verification>(v => v.AccountId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(acc => acc.ProfilePicture)
                .WithOne(pp => pp.Account)
                .HasForeignKey<ProfilePicture>(pp => pp.AccountId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasQueryFilter(a => !a.IsDeleted);
        }
    }
}
