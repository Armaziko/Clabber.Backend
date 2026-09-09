namespace Clabber.Backend.Application.DTOs.RequestDTOs.Auth
{
    public class AuthenticateDto
    {
        public string UserNameOrEmail { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
