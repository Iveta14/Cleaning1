using Cleaning.Data;
using Cleaning.Entities;
using Cleaning.Repositories.IRepositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace Cleaning.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<ApplicationUser> GetUserListWithRole(string roleName)
        {
            var role = _context.Roles.Where(s => s.Name == roleName).FirstOrDefault();

            IQueryable<ApplicationUser> query = _context.Set<ApplicationUser>();
            query = query.Include(s => s.UserRoles).ThenInclude(s => s.Role);
           
            query = query.Where(s => s.UserRoles.FirstOrDefault().RoleId == role.Id).Where(b => b.IsDeleted == false);
            List<ApplicationUser> result = query.ToList();

            return result;
        }

        public bool Add(ApplicationUser user)
        {
            try
            {
                _context.ApplicationUsers.Add(user);
                return true;
            }
            catch
            {
                return false;
            }
        }


        public ApplicationUser? FindByUserName(string? userName)
        {
            if (String.IsNullOrEmpty(userName))
                return null;
            return _context.ApplicationUsers.Where(s => s.UserName == userName).FirstOrDefault();
        }

        public bool Delete(ApplicationUser user)
        {
            user.IsDeleted = true;

            user.LockoutEnd = DateTime.Now.AddYears(1000);
            _context.ApplicationUsers.Update(user);
            int stateNumber = _context.SaveChanges();
            return stateNumber > 0;
        }
    }
}
