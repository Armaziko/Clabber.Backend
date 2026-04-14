using Clabber.Backend.Application.Abstractions;
using Clabber.Backend.Infrastructure.Extensions;
using Clabber.Backend.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Clabber.Backend.Infrastructure
{
    public static class DependencyInjection
    {
        public static void SetUpInfrastructure(this IHostApplicationBuilder builder)
        {
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.SetUpContext();
        }
    }
}
