namespace Clabber.Backend.Infrastructure.Config
{
    public class RightsConfig
    {
        public static readonly string SectionName = "AuthBearerToken:Rights";
        public static readonly string AdminRightsPolicyName = "AdminRights";
        public static readonly string CreatorRightsPolicyName = "CreatorRights";
        public static readonly string SponsorRightsPolicyName = "SponsorRights";
        public List<string> CreatorRights { get; set; } = new();
        public List<string> SponsorRights { get; set; } = new();
        public List<string> AdminRights { get; set; } = new();
    }
}
