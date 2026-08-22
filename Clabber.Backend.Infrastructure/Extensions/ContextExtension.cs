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
            if (builder.Environment.IsDevelopment())
            {
                builder.Services.AddDbContext<ApplicationDbContext>(options =>
                {
                    options.UseSqlite("Data Source=dev_app.db");
                });

                builder.Services.AddDbContext<IdentityDbContext>(options =>
                {
                    options.UseSqlite("Data Source=dev_identity.db");
                });
            }
            else
            {
                var appConnectionStrings = builder.Configuration.GetConnectionString("Application_SqlServer_01") ?? throw new ArgumentException("Connection string is null.");
                var identityConnectionStrings = builder.Configuration.GetConnectionString("Identity_SqlServer_01") ?? throw new ArgumentException("Connection string is null.");


                builder.Services.AddDbContext<ApplicationDbContext>(options =>
                {
                    options.UseSqlServer(appConnectionStrings);
                });

                builder.Services.AddDbContext<IdentityDbContext>(options =>
                {
                    options.UseSqlServer(identityConnectionStrings);
                });
            }
        }
    }
}
