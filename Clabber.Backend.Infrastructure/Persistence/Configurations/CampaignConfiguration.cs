using Clabber.Backend.Domain.Entities.Campaign;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clabber.Backend.Infrastructure.Persistence.Configurations
{
    public class CampaignConfiguration : IEntityTypeConfiguration<Campaign>
    {
        public void Configure(EntityTypeBuilder<Campaign> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(c => c.BudgetTotal).IsRequired().HasPrecision(18,2);
            builder.Property(c => c.Status).IsRequired();
            builder.Property(c => c.StartDate).IsRequired();
            builder.Property(c => c.Type).IsRequired();

            builder.HasMany(c => c.Sponsorships)
                .WithOne(s => s.Campaign)
                .HasForeignKey(s => s.CampaignId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasQueryFilter(c => !c.IsDeleted);
        }
    }
}
