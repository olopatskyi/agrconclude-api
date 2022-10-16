using Microsoft.AspNetCore.Identity;

namespace agrconclude.core.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string AvatarUrl { get; set; }

        public ICollection<UserContract>? Contracts { get; set; }
    }
}