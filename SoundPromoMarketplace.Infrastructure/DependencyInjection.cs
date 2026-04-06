using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SoundPromoMarketplace.Application.Abstractions;
using SoundPromoMarketplace.Infrastructure.Persistence;

namespace SoundPromoMarketplace.Infrastructure
{
    public static class DependencyInjection
    {
        public static void SetUpInfrastructure(this IHostApplicationBuilder builder)
        {
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
