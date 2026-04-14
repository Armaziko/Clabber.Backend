using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Clabber.Backend.Application
{
    public static class DependencyInjection
    {
        public static void SetUpApplication(this IHostApplicationBuilder builder)
        {
            builder.Services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
            });
        }
    }
}
