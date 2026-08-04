namespace Clabber.Backend.Application.DTOs.RequestDTOs.Account
{
    public class PartialUpdateAccountDto
    {
        public Guid Id { get; set; }
        public string? DisplayName { get; set; } = string.Empty;
        public string? Password { get; set; } = string.Empty;
        public string? Mail { get; set; } = string.Empty;
    }
}
