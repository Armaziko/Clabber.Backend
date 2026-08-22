using Clabber.Backend.Domain.Entities.Profile;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Clabber.Backend.Infrastructure.Persistence
{
    public class IdentityDbContext : IdentityDbContext<Account, IdentityRole<Guid>, Guid>
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options)
            : base(options)
        {
        }

        public DbSet<Verification> Verifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply Account and Verification configurations in the identity model
            modelBuilder.ApplyConfiguration(new Configurations.AccountConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.VerificationConfiguration());
        }
    }
}
