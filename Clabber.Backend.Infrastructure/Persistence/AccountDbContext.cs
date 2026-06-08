using Clabber.Backend.Domain.Entities.Profile;
using Clabber.Backend.Infrastructure.Persistence.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Clabber.Backend.Infrastructure.Persistence
{
    public class AccountDbContext : IdentityDbContext<Account, IdentityRole<Guid>, Guid>
    {
        public AccountDbContext(DbContextOptions<AccountDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(AccountConfiguration).Assembly);
        }
    }
}
