namespace Clabber.Backend.Application.Models.Auth
{
    public class UserClaims
    {
        public Guid Id { get; set; }
        public string Role { get; set; } = string.Empty;
    }
}
