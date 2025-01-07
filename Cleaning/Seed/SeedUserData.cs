using Cleaning.Entities;
using Cleaning.Helpers;
using Cleaning.Migrations;
using Microsoft.AspNetCore.Identity;

namespace Cleaning.Seed
{
    public class SeedUserData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            SetAndSaveUser("Admin", "Adminovf", "admin@test.com", "Admin@1234", StaticData.Role_Admin, serviceProvider);
        }

        private static void SetAndSaveUser(string firstName, string lastName, string userEmail, string password, string role, IServiceProvider serviceProvider)
        {
            UserManager<ApplicationUser> userManager =
               serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            if (userManager.FindByNameAsync(userEmail).GetAwaiter().GetResult() == null)
            {
                ApplicationUser user = new()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    UserName = userEmail,
                    Email = userEmail,
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true
                };

                userManager.CreateAsync(user, password).GetAwaiter().GetResult();
                userManager.AddToRoleAsync(user, role).GetAwaiter().GetResult();
            }
        }
    }
}
