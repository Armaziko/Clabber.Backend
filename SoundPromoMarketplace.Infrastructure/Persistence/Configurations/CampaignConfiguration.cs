using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoundPromoMarketplace.Domain.Entities;

namespace SoundPromoMarketplace.Infrastructure.Persistence.Configurations
{
    public class CampaignConfiguration : IEntityTypeConfiguration<Campaign>
    {
        public void Configure(EntityTypeBuilder<Campaign> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(c => c.BudgetTotal).IsRequired().HasPrecision(18,2);
            builder.Property(c => c.Status).IsRequired();
            builder.Property(c => c.StartDate).IsRequired();

            builder.HasMany(ca => ca.Collaborations)
                .WithOne(co => co.Campaign)
                .HasForeignKey(co => co.CampaignId);
        }
    }
}
