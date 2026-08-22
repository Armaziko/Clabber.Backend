using Clabber.Backend.Domain.Entities.Media;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clabber.Backend.Infrastructure.Persistence.Configurations
{
    public class MediaCollectionItemConfiguration : IEntityTypeConfiguration<MediaCollectionItem>
    {
        public void Configure(EntityTypeBuilder<MediaCollectionItem> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasQueryFilter(mc => !mc.IsDeleted);
        }
    }
}
