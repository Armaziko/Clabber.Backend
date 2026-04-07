using Microsoft.EntityFrameworkCore;
using SoundPromoMarketplace.Domain.Entities;

namespace SoundPromoMarketplace.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<BuyerProfile> BuyerProfiles { get; set; }
        public DbSet<CreatorProfile> CreatorProfiles { get; set; }

        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<AudioTrack> AudioTracks { get; set; }
        public DbSet<Collaboration> Collaborations { get; set; }

        public DbSet<SocialChannel> SocialChannels { get; set; }
        public DbSet<CreatorMetricsHistory> CreatorMetricsHistories { get; set; }
        public DbSet<PredictiveAnalysis> PredictiveAnalyses { get; set; }
 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
