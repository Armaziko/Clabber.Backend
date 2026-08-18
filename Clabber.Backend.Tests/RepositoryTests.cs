using Clabber.Backend.Application.Abstractions;
using Clabber.Backend.Application.Specification;
using Clabber.Backend.Domain.Entities.Campaign;
using Clabber.Backend.Domain.Entities.Profile;
using Clabber.Backend.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Clabber.Backend.Tests
{
    #region InMemoryDbContext
    // In-memory database context implementation to provide a valid DbContext object for Repository unit tests.
    public static class InMemoryDbContextProvider
    {
        public static ApplicationDbContext GetApplicationDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid()
                .ToString())
                .Options;

            var dbContext = new ApplicationDbContext(options);
            dbContext.Database.EnsureCreated();
            return dbContext;
        }
    }
    #endregion

    public class RepositoryTests
    {
        [Fact]
        public async Task Add_Should_Add_Item_To_Repository()
        {
            //Arrange
            var dbContext = InMemoryDbContextProvider.GetApplicationDbContext();
            var unitOfWork = new UnitOfWork(dbContext);
            IRepository<Campaign> repo = unitOfWork.Repository<Campaign>();
            var campaign = new Campaign(Guid.NewGuid())
            {
                BudgetTotal = 245.21m,
                IsDeleted = false,
                StartDate = DateTime.UtcNow,
                OwnerSponsorId = Guid.NewGuid(),
                Status = Domain.Enums.CampaignStatus.Active,
                PromotedProductId = Guid.NewGuid(),
                Type = Domain.Enums.CampaignType.Collaboration
            };

            //Act
            repo.Add(campaign);
            await unitOfWork.CommitAsync();

            var all = await repo.GetAllAsync();

            //Assert
            Assert.Single(all);
            Assert.Equal(campaign.Id, all[0].Id);
            Assert.Equal(245.21m, all[0].BudgetTotal);
        }
    }
}
