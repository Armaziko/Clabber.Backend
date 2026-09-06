using Clabber.Backend.Api.Config;

namespace Clabber.Backend.Api.Extensions
{
    public static class AuthhorizationExtension
    {
        public static void SetUpAuthorization(this IHostApplicationBuilder builder)
        {
            var config = builder.Configuration.GetSection("AuthDetails:Rights").Get<RightsConfig>();
            if (config is null)
            {
                throw new InvalidOperationException("RightsConfig object couldn't be created using AuthDetails:Rights.");
            }
            builder.Services.AddAuthorizationBuilder()
                .AddPolicy(RightsConfig.AdminRightsPolicyName, policy =>
                {
                    policy.RequireRole(config.AdminRights);
                }).AddPolicy(RightsConfig.SponsorRightsPolicyName, policy =>
                {
                    policy.RequireRole(config.SponsorRights);
                }).AddPolicy(RightsConfig.CreatorRightsPolicyName, policy =>
                {
                    policy.RequireRole(RightsConfig.CreatorRightsPolicyName);
                });
        }
    }
}
