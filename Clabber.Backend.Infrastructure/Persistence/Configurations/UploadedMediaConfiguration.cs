using Clabber.Backend.Domain.Entities.Media;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clabber.Backend.Infrastructure.Persistence.Configurations
{
    public class UploadedMediaConfiguration : IEntityTypeConfiguration<UploadedMedia>
    {
        public void Configure(EntityTypeBuilder<UploadedMedia> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Title);
            builder.Property(x => x.S3Url).IsRequired();
            builder.Property(x => x.MediaType).IsRequired();
            builder.Property(x => x.SizeMB).IsRequired();

            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
