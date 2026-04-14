using Clabber.Backend.Api.Extensions;

namespace Clabber.Backend.Api
{
    public static class DependencyInjection
    {
        public static void SetupApi(this IHostApplicationBuilder builder)
        {
            builder.SetupCors();
            builder.SetUpIdentity();
        }
    }
}
