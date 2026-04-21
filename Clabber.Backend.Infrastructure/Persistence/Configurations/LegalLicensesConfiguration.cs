using Clabber.Backend.Domain.Entities.Legal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clabber.Backend.Infrastructure.Persistence.Configurations
{
    public class LegalLicensesConfiguration : IEntityTypeConfiguration<LegalLicenses>
    {
        public void Configure(EntityTypeBuilder<LegalLicenses> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.LicenseText).IsRequired();
            builder.Property(x => x.DigitalSignature).IsRequired();
        }
    }
}
