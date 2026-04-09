using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SoundPromoMarketplace.Infrastructure.Persistence;

namespace SoundPromoMarketplace.Infrastructure.Extensions
{
    public static class ContextExtension
    {
        public static void SetUpContext(this IHostApplicationBuilder builder)
        {
            var connectionStrings = builder.Configuration.GetConnectionString("SqlServer_01") ?? throw new ArgumentException("Connection string is null.");

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionStrings);
            });
        }
    }
}
