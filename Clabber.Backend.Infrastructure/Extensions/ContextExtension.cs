using Clabber.Backend.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Clabber.Backend.Infrastructure.Extensions
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
