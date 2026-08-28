using Clabber.Backend.Domain.Entities.Campaign;
using Clabber.Backend.Domain.Entities.Chat;
using Clabber.Backend.Domain.Entities.Legal;
using Clabber.Backend.Domain.Entities.Media;
using Clabber.Backend.Domain.Entities.Profile;
using Clabber.Backend.Domain.Entities.Profiles;
using Clabber.Backend.Domain.Entities.Tool;
using Clabber.Backend.Domain.Entities.Transactions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Clabber.Backend.Infrastructure.Persistence
{
    public class DataSeeder
    {
        private readonly ApplicationDbContext appContext;
        private readonly IdentityDbContext identityContext;
        private readonly UserManager<Account> _userManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;

        public DataSeeder(ApplicationDbContext appContext, IdentityDbContext identityDbContext, UserManager<Account> userManager, RoleManager<IdentityRole<Guid>> roleManager)
        {
            this.appContext = appContext;
            this.identityContext = identityDbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedAsync()
        {
            // Apply pending migrations (development only)
            await appContext.Database.MigrateAsync();
            await identityContext.Database.MigrateAsync();

            if (await identityContext.Users.AnyAsync()) return; // already seeded

            // Roles
            var roles = new[] { "Admin", "Sponsor", "Creator" };
            foreach (var role in roles)
            {
                if (!await _roleManager.RoleExistsAsync(role))
                    await _roleManager.CreateAsync(new IdentityRole<Guid>(role));
            }

            // Create accounts
            var sponsorAccount = Account.CreateNew("Acme Sponsor", "acmespon", "sponsor@acme.test");
            sponsorAccount.UserName = "sponsor@acme.test";
            var creatorAccount = Account.CreateNew("Jane Creator", "littlefinger", "jane.creator@test.local");
            creatorAccount.UserName = "jane.creator@test.local";
            var adminAccount = Account.CreateNew("Platform Admin", "goat", "admin@test.local");
            adminAccount.UserName = "admin@test.local";

            await _userManager.CreateAsync(sponsorAccount, "P@ssw0rd123!");
            await _userManager.AddToRoleAsync(sponsorAccount, "Sponsor");

            await _userManager.CreateAsync(creatorAccount, "P@ssw0rd123!");
            await _userManager.AddToRoleAsync(creatorAccount, "Creator");

            await _userManager.CreateAsync(adminAccount, "P@ssw0rd123!");
            await _userManager.AddToRoleAsync(adminAccount, "Admin");

            // Profiles
            var sponsorProfile = new SponsorProfile(Guid.NewGuid())
            {
                AccountId = sponsorAccount.Id,
                OrganizationName = "ACME Inc",
                IsDeleted = false,
            };

            var creatorProfile = new CreatorProfile(Guid.NewGuid())
            {
                AccountId = creatorAccount.Id,
                Bio = "Independent creator focusing on short-form music content.",
                MainGenre = "Music",
                Country = "US",
                OverallRating = 4.6M,
                IsDeleted = false
            };

            appContext.SponsorProfiles.Add(sponsorProfile);
            appContext.CreatorProfiles.Add(creatorProfile);

            // Media and collections
            var uploaded = new UploadedMedia(Guid.NewGuid())
            {
                AccountId = creatorAccount.Id,
                Title = "Sample Track",
                S3Url = "https://example.test/media/track.mp3",
                MediaType = Domain.Enums.MediaType.Audio,
                SizeMB = 3.5M,
                CreatedAt = DateTime.UtcNow,
                IsDeleted = false
            };

            var mediaCollection = new MediaCollection(Guid.NewGuid()) { OwnerId = creatorProfile.Id };
            var collectionItem = new MediaCollectionItem(Guid.NewGuid()) { MediaCollectionId = mediaCollection.Id, UploadedMediaId = uploaded.Id };

            appContext.UploadedMedias.Add(uploaded);
            appContext.MediaCollections.Add(mediaCollection);
            appContext.MediaCollectionItems.Add(collectionItem);

            // Profile pictures
            var profilePicMedia = new UploadedMedia(Guid.NewGuid())
            {
                AccountId = sponsorAccount.Id,
                Title = "Sponsor Logo",
                S3Url = "https://example.test/media/logo.png",
                MediaType = Domain.Enums.MediaType.Image,
                SizeMB = 0.12M,
                CreatedAt = DateTime.UtcNow,
                IsDeleted = false
            };

            var sponsorPicture = new ProfilePicture(Guid.NewGuid()) { AccountId = sponsorAccount.Id, UploadedMediaId = profilePicMedia.Id, IsDeleted = false };
            appContext.UploadedMedias.Add(profilePicMedia);
            appContext.ProfilePictures.Add(sponsorPicture);

            // Social channel for creator
            var channel = new SocialChannel(Guid.NewGuid())
            {
                CreatorId = creatorProfile.Id,
                ProfilePictureId = sponsorPicture.Id,
                Platform = Domain.Enums.SocialMediaPlatform.TitTok,
                Handle = "@jane_music",
                ExternalId = "12345",
                FollowerCount = 120_000,
                GeneralGenre = "Pop",
                EngagementRate = 0.08M,
                LastScrapedAt = DateTime.UtcNow,
                IsDeleted = false
            };

            appContext.SocialChannels.Add(channel);

            // Promoted product and campaign
            var product = new PromotedProduct(Guid.NewGuid())
            {
                SponsorId = sponsorProfile.Id,
                Title = "ACME Energy Drink",
                Description = "New flavor launch",
                Category = "Beverage",
                IsDigitial = false,
                ExternalUrl = "https://acme.test/product/energy",
                DateCreated = DateTime.UtcNow,
                IsDeleted = false
            };
            appContext.PromotedProducts.Add(product);

            var campaign = new Campaign(Guid.NewGuid())
            {
                OwnerSponsorId = sponsorProfile.Id,
                PromotedProductId = product.Id,
                BudgetTotal = 10000M,
                Type = Domain.Enums.CampaignType.Sponsorship,
                Status = Domain.Enums.CampaignStatus.Active,
                StartDate = DateTime.UtcNow.AddDays(-2),
                IsDeleted = false
            };
            appContext.Campaigns.Add(campaign);

            var sponsorship = new Sponsorship(Guid.NewGuid())
            {
                CampaignId = campaign.Id,
                CreatorId = creatorProfile.Id,
                ChannelId = channel.Id,
                AgreedPrice = 1500M,
                Status = Domain.Enums.CollaborationStatus.Accepted,
                TrackingLink = "https://track.test/t/abc123",
                MilestoneBonus = 200M,
                TargetMetricGoal = 50000,
                ActualMetricAchieved = 0,
                CreatedAt = DateTime.UtcNow,
                IsDeleted = false
            };
            appContext.Sponsorships.Add(sponsorship);

            // Transactions, deliverables, licenses
            var escrow = new EscrowTransaction(Guid.NewGuid())
            {
                SponsorshipId = sponsorship.Id,
                Amount = 1500M,
                Currency = "USD",
                Type = Domain.Enums.EscrowTransactionType.Deposit,
                ProcessingProvider = "Stripe",
                ProviderTransactionId = "txn_abc123",
                CreatedAt = DateTime.UtcNow,
                IsDeleted = false
            };
            appContext.EscrowTransactions.Add(escrow);

            var deliverable = new Deliverables(Guid.NewGuid()) { SponsorshipId = sponsorship.Id, S3Url = "https://example.test/deliverable/1", Status = Domain.Enums.DeliverablesStatus.PendingReview, CreatedAt = DateTime.UtcNow };
            appContext.Deliverables.Add(deliverable);

            var license = new LegalLicenses(Guid.NewGuid()) { SponsorshipId = sponsorship.Id, LicenseText = "Standard usage license", DigitalSignature = "sig123", CreatedAt = DateTime.UtcNow };
            appContext.LegalLicenses.Add(license);

            // Creator metrics and predictive analysis
            var metrics = new CreatorMetricsHistory(Guid.NewGuid()) { ChannelId = channel.Id, SnapshotDate = DateTime.UtcNow.AddDays(-7), ViewsMedian = 50000, SharesMedian = 2000, SaveRate = 0.03M };
            appContext.CreatorMetricsHistories.Add(metrics);

            var prediction = new PredictiveAnalysis(Guid.NewGuid()) { SponsorId = sponsorProfile.Id, ChannelId = channel.Id, AudioTrackId = uploaded.Id, NeuralVibeScore = 0.84M, AlgorithmicProbability = 0.72M, PredictedViewRange = "40k-80k", SuggestedOptimalBid = 1.25M, CreatedAt = DateTime.UtcNow, IsDeleted = false };
            appContext.PredictiveAnalyses.Add(prediction);

            // Chat and messages
            var chat = new Chat(Guid.NewGuid()) { IsGroup = false, CreatedAt = DateTime.UtcNow, IsDeleted = false };
            appContext.Chats.Add(chat);
            var participantSponsor = new ChatParticipant(Guid.NewGuid()) { ChatId = chat.Id, AccountId = sponsorAccount.Id, IsDeleted = false };
            var participantCreator = new ChatParticipant(Guid.NewGuid()) { ChatId = chat.Id, AccountId = creatorAccount.Id, IsDeleted = false };
            appContext.ChatParticipants.AddRange(participantSponsor, participantCreator);

            var message = new Message(Guid.NewGuid()) { ChatId = chat.Id, SenderAccountId = creatorAccount.Id, Content = "Hello! Excited to start the collaboration.", SentAt = DateTime.UtcNow, IsRead = false, IsDeleted = false };
            appContext.Messages.Add(message);

            // Friendships
            var friendship = new Friendship(Guid.NewGuid()) { RequesterId = creatorProfile.Id, ReceiverId = creatorProfile.Id, Status = Domain.Enums.FriendshipStatus.Accepted, CreatedAt = DateTime.UtcNow, IsDeleted = false };
            appContext.Friendships.Add(friendship);

            // Verifications
            var verification = new Verification(Guid.NewGuid()) { AccountId = creatorAccount.Id, Status = Domain.Enums.VerificationStatus.Verified, CreatedAt = DateTime.UtcNow.AddDays(-30), LastUpdatedAt = DateTime.UtcNow };
            identityContext.Verifications.Add(verification);

            await identityContext.SaveChangesAsync();

            await appContext.SaveChangesAsync();
        }
    }
}
