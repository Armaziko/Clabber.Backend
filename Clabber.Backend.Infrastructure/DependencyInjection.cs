using Clabber.Backend.Application.Abstractions;
using Clabber.Backend.Infrastructure.Config;
using Clabber.Backend.Infrastructure.Extensions;
using Clabber.Backend.Infrastructure.Persistence;
using Clabber.Backend.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Clabber.Backend.Infrastructure
{
    public static class DependencyInjection
    {
        public static void SetUpInfrastructure(this IHostApplicationBuilder builder)
        {
            builder.Services.AddOptions<AuthBearerTokenConfig>().BindConfiguration(AuthBearerTokenConfig.SectionName);
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IBearerTokenGenerator, BearerTokenGenerator>();
            builder.Services.AddTransient<DataSeeder>();

            builder.SetUpContext();
        }
    }
}
