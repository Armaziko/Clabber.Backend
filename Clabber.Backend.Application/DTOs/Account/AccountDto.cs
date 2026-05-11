namespace Clabber.Backend.Application.DTOs.Account
{
    public class AccountDto
    {
        public Guid Id { get; set; }
        public string DisplayName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
