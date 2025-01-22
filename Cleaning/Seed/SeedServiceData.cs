using Cleaning.Data;
using Cleaning.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Cleaning.Seed
{
    public class SeedServiceData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any categories.
                if (context.Services.Any())
                {
                    return;   // DB has been seeded
                }

                context.Services.AddRange(
                    new Service
                    {
                        Name = "Почистване след ремонт",
                        Description = "Oписание.",
                        Price = 4.90m,
                        ThumbnailImagePath = "",
                        PhotoBeforePath = "",
                        PhotoAfterPath = "",
                    },
                    new Service
                    {
                        Name = "Почистване на жилища",
                        Description = "Oписание.",
                        Price = 3.50m,
                        ThumbnailImagePath = "",
                        PhotoBeforePath = "",
                        PhotoAfterPath = "",
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
