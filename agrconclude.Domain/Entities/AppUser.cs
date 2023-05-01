using Microsoft.AspNetCore.Identity;

namespace agrconclude.Domain.Entities
{
    public class AppUser : IdentityUser<string>
    {
        public string FirstName { get; set; } = string.Empty;

        public string? LastName { get; set; }

        public string AvatarUrl { get; set; } = string.Empty;
    }
}