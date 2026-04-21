using Clabber.Backend.Domain.Entities.Profiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clabber.Backend.Infrastructure.Persistence.Configurations
{
    public class CreatorProfileConfiguration : IEntityTypeConfiguration<CreatorProfile>
    {
        public void Configure(EntityTypeBuilder<CreatorProfile> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Bio).IsRequired(false).HasMaxLength(1024);
            builder.Property(c => c.MainGenre).IsRequired().HasMaxLength(64);
            builder.Property(c => c.Country).IsRequired().HasMaxLength(64);
            builder.Property(c => c.OverallRating).IsRequired().HasPrecision(3,2);

            builder.HasMany(c => c.Sponsorships)
                .WithOne(co => co.CreatorProfile)
                .HasForeignKey(co => co.CreatorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.SocialChannels)
                .WithOne(sc => sc.CreatorProfile)
                .HasForeignKey(sc => sc.CreatorId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasQueryFilter(c => !c.IsDeleted);
        }
    }
}
