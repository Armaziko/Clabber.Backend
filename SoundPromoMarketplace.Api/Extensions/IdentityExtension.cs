using Microsoft.AspNetCore.Identity;
using SoundPromoMarketplace.Domain.Entities;
using SoundPromoMarketplace.Infrastructure.Persistence;

namespace SoundPromoMarketplace.Api.Extensions
{
    public static class IdentityExtension
    {
        public static void SetUpIdentity(this IHostApplicationBuilder builder)
        {
            builder.Services.AddIdentity<Account, IdentityRole<Guid>>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
        }
    }
}
