using Microsoft.AspNetCore.Identity;

namespace Cleaning.Entities
{
    public class ApplicationUserRole : IdentityUserRole<string> //репрезентира свъзващата таблица
    {
        //navigation property
        //релация към потребител и роля
        public virtual ApplicationUser User { get; set; }
        public virtual ApplicationRole Role { get; set; }
    }
}
