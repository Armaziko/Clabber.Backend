using Clabber.Backend.Domain.Entities.Profiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clabber.Backend.Infrastructure.Persistence.Configurations
{
    public class SponsorProfileConfiguration : IEntityTypeConfiguration<SponsorProfile>
    {
        public void Configure(EntityTypeBuilder<SponsorProfile> builder)
        {
            builder.HasKey(sp => sp.Id);

            builder.Property(sp => sp.OrganizationName).IsRequired(false).HasMaxLength(256);

            builder.HasMany(sp => sp.Campaigns)
                .WithOne(c => c.OwnnerSponsor)
                .HasForeignKey(c => c.OwnerSponsorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(sp => sp.PredictiveAnalyses)
                .WithOne(pa => pa.Sponsor)
                .HasForeignKey(pa => pa.SponsorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(sp => sp.PromotedProducts)
                .WithOne(pp => pp.SponsorProfile)
                .HasForeignKey(pp => pp.SponsorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasQueryFilter(sp => !sp.IsDeleted);
        }
    }
}
