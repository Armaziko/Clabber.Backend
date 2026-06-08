using Clabber.Backend.Domain.Entities.Profile;
using Clabber.Backend.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;

namespace Clabber.Backend.Api.Extensions
{
    public static class IdentityExtension
    {
        public static void SetUpIdentity(this IHostApplicationBuilder builder)
        {
            builder.Services.AddIdentity<Account, IdentityRole<Guid>>()
                .AddEntityFrameworkStores<AccountDbContext>()
                .AddDefaultTokenProviders();
        }
    }
}
