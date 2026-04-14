using Clabber.Backend.Api.Cors;

namespace Clabber.Backend.Api.Extensions
{
    public static class CorsExtensions
    {
        public static void SetupCors(this IHostApplicationBuilder builder)
        {
            var allowedOrigins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>() ?? [];
            var allowedMethods = builder.Configuration.GetSection("Cors:AllowedMethods").Get<string[]>() ?? [];
            var allowedHeaders = builder.Configuration.GetSection("Cors:AllowedHeaders").Get<string[]>() ?? [];

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(CorsPolicies.AllowFronted, policy =>
                {
                    policy
                    .WithOrigins(allowedOrigins)
                    .WithMethods(allowedMethods)
                    .WithHeaders(allowedHeaders)
                    .AllowCredentials();
                });

                options.AddPolicy(CorsPolicies.PublicApi, policy =>
                {
                    policy.AllowAnyOrigin()
                          .WithMethods("GET")
                          .WithHeaders("Content-Type", "Accept");
                });
            });
        }
    }
}
