using Cleaning.Entities;
using Cleaning.Helpers;
using Microsoft.AspNetCore.Identity;

namespace Cleaning.Seed
{
    public class SeedRoleData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            //създаваме роля на администратор в таблицата с ролите
            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
            if (!roleManager.RoleExistsAsync(StaticData.Role_Admin).GetAwaiter().GetResult())
            {
                roleManager.CreateAsync(new ApplicationRole(StaticData.Role_Admin)).GetAwaiter().GetResult();
            }
        }
    }
}
