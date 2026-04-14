using Clabber.Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clabber.Backend.Infrastructure.Persistence.Configurations
{
    public class AudioTrackConfiguration : IEntityTypeConfiguration<AudioTrack>
    {
        public void Configure(EntityTypeBuilder<AudioTrack> builder)
        {
            builder.HasKey(at => at.Id);

            builder.HasIndex(at => at.S3Url).IsUnique();

            builder.Property(at => at.Title).IsRequired().HasMaxLength(128);

            builder.Property(at => at.S3Url).IsRequired().HasMaxLength(512);

            builder.Property(at => at.Bpm).IsRequired();

            builder.Property(at => at.Genre).IsRequired().HasMaxLength(64);

            builder.Property(at => at.DurationSeconds).IsRequired();

            builder.HasMany(at => at.Campaigns)
                .WithOne(ca => ca.AudioTrack)
                .HasForeignKey(ca => ca.AudioTrackId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(at => at.PredictiveAnalyses)
                .WithOne(pa => pa.AudioTrack)
                .HasForeignKey(pa => pa.AudioTrackId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
