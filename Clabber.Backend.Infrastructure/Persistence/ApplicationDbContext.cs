using Clabber.Backend.Domain.Entities.Campaign;
using Clabber.Backend.Domain.Entities.Chat;
using Clabber.Backend.Domain.Entities.Legal;
using Clabber.Backend.Domain.Entities.Media;
using Clabber.Backend.Domain.Entities.Profile;
using Clabber.Backend.Domain.Entities.Profiles;
using Clabber.Backend.Domain.Entities.Tool;
using Clabber.Backend.Domain.Entities.Transactions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Clabber.Backend.Infrastructure.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<Account, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Profile group
        public DbSet<SponsorProfile> SponsorProfiles { get; set; }
        public DbSet<CreatorProfile> CreatorProfiles { get; set; }
        public DbSet<SocialChannel> SocialChannels { get; set; }
        public DbSet<Friendship> Friendships { get; set; }
        public DbSet<Verification> Verifications { get; set; }

        // Chat group
        public DbSet<Chat> Chats { get; set; }
        public DbSet<ChatParticipant> ChatParticipants { get; set; }
        public DbSet<Message> Messages { get; set; }

        // Campaign group
        public DbSet<Campaign> Campaigns { get; set;  }
        public DbSet<PromotedProduct> PromotedProducts { get; set; }
        public DbSet<Sponsorship> Sponsorships { get; set; }

        // Legal group
        public DbSet<Deliverables> Deliverables { get; set; }
        public DbSet<LegalLicenses> LegalLicenses { get; set; }

        // Media group
        public DbSet<UploadedMedia> UploadedMedias { get; set; }
        public DbSet<MediaCollection> MediaCollections { get; set; }
        public DbSet<MediaCollectionItem> MediaCollectionItems { get; set; }
        public DbSet<ProfilePicture> ProfilePictures { get; set; }

        // Tool group
        public DbSet<CreatorMetricsHistory> CreatorMetricsHistories { get; set; }
        public DbSet<PredictiveAnalysis> PredictiveAnalyses { get; set; }

        // Transaction group
        public DbSet<EscrowTransaction> EscrowTransactions { get; set; }
 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}