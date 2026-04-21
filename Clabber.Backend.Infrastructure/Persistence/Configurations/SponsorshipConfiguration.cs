using Clabber.Backend.Domain.Entities.Campaign;
using Clabber.Backend.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clabber.Backend.Infrastructure.Persistence.Configurations
{
    public class SponsorshipConfiguration : IEntityTypeConfiguration<Sponsorship>
    {
        public void Configure(EntityTypeBuilder<Sponsorship> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(co => co.AgreedPrice).IsRequired(false);
            builder.Property(co => co.Status).IsRequired().HasDefaultValue(CollaborationStatus.Requested);
            builder.Property(co => co.TrackingLink).IsRequired(false);
            builder.Property(co => co.MilestoneBonus).IsRequired(true);
            builder.Property(co => co.TargetMetricGoal).IsRequired(true);
            builder.Property(co => co.ActualMetricAchieved).IsRequired(true);

            builder.HasMany(co => co.Transactions)
                .WithOne(et => et.Sponsorship)
                .HasForeignKey(et => et.SponsorshipId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(co => co.Deliverables)
                .WithOne(d => d.Sponsorship)
                .HasForeignKey(d => d.SponsorshipId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(co => co.LegalLicenses)
                .WithOne(ll => ll.Sponsorship)
                .HasForeignKey(ll => ll.SponsorshipId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasQueryFilter(co => !co.IsDeleted);
        }
    }
}
