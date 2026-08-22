using Clabber.Backend.Domain.Entities.Profile;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clabber.Backend.Infrastructure.Persistence.Configurations
{
    public class VerificationConfiguration : IEntityTypeConfiguration<Verification>
    {
        public void Configure(EntityTypeBuilder<Verification> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.AccountId);

            builder.HasIndex(x => x.Status);

            builder.Property(v => v.Status).IsRequired();

            builder.HasOne(x => x.Account)
                .WithOne(x => x.Verification)
                .HasForeignKey<Verification>(x => x.AccountId).OnDelete(DeleteBehavior.Cascade);

            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
