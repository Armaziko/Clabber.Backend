namespace Clabber.Backend.Application.DTOs.RequestDTOs.Account
{
    public class CreateAccountDto
    {
        public string DisplayName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Mail { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
