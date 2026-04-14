using Clabber.Backend.Domain.Entities;
using Clabber.Backend.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clabber.Backend.Infrastructure.Persistence.Configurations
{
    public class CollaborationConfiguration : IEntityTypeConfiguration<Collaboration>
    {
        public void Configure(EntityTypeBuilder<Collaboration> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(co => co.AgreedPrice).IsRequired(false);

            builder.Property(co => co.Status).IsRequired().HasDefaultValue(CollaborationStatus.Requested);

            builder.Property(co => co.TrackingLink).IsRequired(false);
        }
    }
}
