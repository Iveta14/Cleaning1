using Microsoft.AspNetCore.Identity;

namespace Cleaning.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; } //релация
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}