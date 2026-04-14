using Clabber.Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clabber.Backend.Infrastructure.Persistence.Configurations
{
    public class BuyerProfileConfiguration : IEntityTypeConfiguration<BuyerProfile>
    {
        public void Configure(EntityTypeBuilder<BuyerProfile> builder)
        {
            builder.HasKey(bp => bp.Id);

            builder.Property(bp => bp.Industry).IsRequired().HasMaxLength(256);
            builder.Property(bp => bp.OrganizationName).IsRequired(false).HasMaxLength(256);

            builder.HasMany(bp => bp.Campaigns)
                .WithOne(c => c.Buyer)
                .HasForeignKey(c => c.BuyerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(bp => bp.AudioTracks)
                .WithOne(at => at.Buyer)
                .HasForeignKey(at => at.BuyerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(bp => bp.PredictiveAnalyses)
                .WithOne(pa => pa.Buyer)
                .HasForeignKey(pa => pa.BuyerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
