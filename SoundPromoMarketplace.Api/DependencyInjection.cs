using SoundPromoMarketplace.Api.Extensions;

namespace SoundPromoMarketplace.Api
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
