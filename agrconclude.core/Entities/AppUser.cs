using Microsoft.AspNetCore.Identity;

namespace agrconclude.core.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        ICollection<Contract>? Contracts { get; set; }
    }
}