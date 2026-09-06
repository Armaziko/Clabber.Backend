namespace Clabber.Backend.Api.Options
{
    public record AuthOptions
    {
        public static string NameTitle { get; } = "AuthDetails";
        public string ValidIssuer { get; set; } = default!;
        public string ValidAudience { get; set; } = default!;
        public string IssuerSigningKey { get; set; } = default!;
        public string AuthCookieName { get; set; } = default!;
    }
}
