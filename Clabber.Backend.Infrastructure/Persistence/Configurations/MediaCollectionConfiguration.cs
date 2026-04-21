using Clabber.Backend.Domain.Entities.Media;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clabber.Backend.Infrastructure.Persistence.Configurations
{
    public class MediaCollectionConfiguration : IEntityTypeConfiguration<MediaCollection>
    {
        public void Configure(EntityTypeBuilder<MediaCollection> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(mc => mc.MediaCollectionItems)
                .WithOne(mci => mci.MediaCollection)
                .HasForeignKey(mci => mci.MediaCollectionId);

            builder.HasQueryFilter(mc => !mc.IsDeleted);
        }
    }
}
