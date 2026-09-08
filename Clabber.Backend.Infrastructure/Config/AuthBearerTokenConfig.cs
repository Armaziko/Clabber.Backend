namespace Clabber.Backend.Infrastructure.Config
{
    public record AuthBearerTokenConfig
    {
        public static string SectionName { get; } = "AuthBearerToken";
        public string ValidIssuer { get; set; } = default!;
        public string ValidAudience { get; set; } = default!;
        public string IssuerSigningKey { get; set; } = default!;
        public string AuthCookieName { get; set; } = default!;
        public int TokenLifetimeMinutes { get; set; }
    }
}
