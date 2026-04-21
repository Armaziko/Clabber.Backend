using Clabber.Backend.Domain.Entities.Tool;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clabber.Backend.Infrastructure.Persistence.Configurations
{
    public class CreatorMetricsHistoryConfiguration : IEntityTypeConfiguration<CreatorMetricsHistory>
    {
        public void Configure(EntityTypeBuilder<CreatorMetricsHistory> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasIndex(C => C.SnapshotDate);

            builder.Property(c => c.SnapshotDate).IsRequired();

            builder.Property(c => c.ViewsMedian).IsRequired();

            builder.Property(c => c.SharesMedian).IsRequired();

            builder.Property(c => c.SaveRate).IsRequired().HasPrecision(5, 2);
        }
    }
}
