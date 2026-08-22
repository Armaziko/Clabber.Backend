using Clabber.Backend.Domain.Entities.Legal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clabber.Backend.Infrastructure.Persistence.Configurations
{
    public class DeliverablesConfiguration : IEntityTypeConfiguration<Deliverables>
    {
        public void Configure(EntityTypeBuilder<Deliverables> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(d => d.S3Url).IsRequired(false);
            builder.Property(d => d.Status).IsRequired();

            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
