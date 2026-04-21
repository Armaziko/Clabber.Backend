using Clabber.Backend.Domain.Entities.Campaign;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clabber.Backend.Infrastructure.Persistence.Configurations
{
    public class PromotedProductConfiguration : IEntityTypeConfiguration<PromotedProduct>
    {
        public void Configure(EntityTypeBuilder<PromotedProduct> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(p => p.Title).IsUnique(false);
            builder.Property(p => p.Title).IsRequired().HasMaxLength(128);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(4096);
            builder.Property(p => p.Category).IsRequired().HasMaxLength(128);
            builder.Property(p => p.IsDigitial).IsRequired();
            builder.Property(p => p.ExternalUrl).IsRequired(false);

            builder.HasQueryFilter(p => !p.IsDeleted);
        }
    }
}
