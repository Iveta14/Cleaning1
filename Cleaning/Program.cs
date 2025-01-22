using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Cleaning.Data;
using Cleaning.Entities;
using Cleaning.Seed;
using Cleaning.Repositories.IRepositories;
using Cleaning.Repositories;
using Cleaning.Services;
using Cleaning.Services.IServices;
namespace Cleaning
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");

            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddDefaultIdentity<ApplicationUser>().AddRoles<ApplicationRole>().AddEntityFrameworkStores<ApplicationDbContext>(); //identity ++
            //builder.Services.AddRazorPages().AddRazorPagesOptions(options => {
            //    options.Conventions.AddAreaPageRoute("Identity", "/Account/Login", "");
            //}); //identity, use razor pages
            //https://stackoverflow.com/questions/46117717/how-to-change-starting-page-using-razor-pages-in-net-core-2

            builder.Services.Configure<IdentityOptions>(options =>
            {
                // Default Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
                options.Password.RequiredUniqueChars = 1;
            });

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                SeedRoleData.Initialize(services);
                SeedUserData.Initialize(services);
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapRazorPages(); //добавя поддръжка на razor страниците

            app.MapControllerRoute(
                name: "area",
                pattern: "{area}/{controller}/{action}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
