using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace SoundPromoMarketplace.Application
{
    public static class DependencyInjection
    {
        public static void SetUpApplication(this IHostApplicationBuilder builder)
        {
            builder.Services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(typeof(SoundPromoMarketplace.Application.DependencyInjection).Assembly);
            });
        }
    }
}
