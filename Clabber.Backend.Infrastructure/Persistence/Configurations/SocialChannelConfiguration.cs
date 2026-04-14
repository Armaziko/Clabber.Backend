using Clabber.Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clabber.Backend.Infrastructure.Persistence.Configurations
{
    public class SocialChannelConfiguration : IEntityTypeConfiguration<SocialChannel>
    {
        public void Configure(EntityTypeBuilder<SocialChannel> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Handle).IsUnique();
            builder.HasIndex(x => new { x.Platform, x.ExternalId }).IsUnique();

            builder.Property(sc => sc.Platform).IsRequired();
            builder.Property(sc => sc.Handle).IsRequired().HasMaxLength(32);
            builder.Property(sc => sc.FollowerCount).IsRequired();
            builder.Property(sc => sc.EngagementRate).IsRequired().HasPrecision(18, 2);
            builder.Property(sc => sc.LastScrapedAt).IsRequired();
            builder.Property(sc => sc.ExternalId).IsRequired().HasMaxLength(256);

            builder.HasMany(sc => sc.CreatorMetricsHistories)
                .WithOne(cmh => cmh.SocialChannel)
                .HasForeignKey(cmh => cmh.ChannelId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(sc => sc.Collaborations)
                .WithOne(co => co.SocialChannel)
                .HasForeignKey(co => co.ChannelId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(sc => sc.PredictiveAnalyses)
                .WithOne(pa => pa.SocialChannel)
                .HasForeignKey(pa => pa.ChannelId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
