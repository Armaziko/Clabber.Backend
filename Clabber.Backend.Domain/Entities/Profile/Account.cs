using Microsoft.AspNetCore.Identity;

namespace Clabber.Backend.Domain.Entities.Profile
{
    public class Account : IdentityUser<Guid>
    {
        public string DisplayName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set;  }
        public bool IsDeleted { get; set; }

        // Navigation properties
        public Verification? Verification { get; set; } = default!;

        public static Account CreateNew(string displayName, string email)
        {
            return new Account()
            {
                Id = Guid.NewGuid(),
                Email = email,
                DisplayName = displayName,
                CreatedAt = DateTime.UtcNow,
                IsDeleted = false
            };
        }
    }
}
