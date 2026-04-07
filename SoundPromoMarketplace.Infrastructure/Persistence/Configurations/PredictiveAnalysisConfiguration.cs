using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoundPromoMarketplace.Domain.Entities;

namespace SoundPromoMarketplace.Infrastructure.Persistence.Configurations
{
    public class PredictiveAnalysisConfiguration : IEntityTypeConfiguration<PredictiveAnalysis>
    {
        public void Configure(EntityTypeBuilder<PredictiveAnalysis> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(pa => pa.NeuralVibeScore).IsRequired().HasPrecision(5,4);

            builder.Property(pa => pa.AlgorithmicProbability).IsRequired().HasPrecision(5,4);

            builder.Property(pa => pa.PredictedViewRange).IsRequired();

            builder.Property(pa => pa.SuggestedOptimalBid).IsRequired().HasPrecision(18,2);

            builder.Property(pa => pa.CreatedAt).IsRequired();
        }
    }
}
