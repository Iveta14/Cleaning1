using Cleaning.Data;
using Cleaning.Entities;
using Cleaning.Repositories.IRepositories;
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

        public List<ApplicationUser> GetUserListWithRole(string role)
        {
            IQueryable<ApplicationUser> query = _context.Set<ApplicationUser>();
            query = query.Include(s => s.UserRoles).ThenInclude(s => s.Role);
           
            query = query.Where(s => s.UserRoles.FirstOrDefault().RoleId == role);
            List<ApplicationUser> result = query.ToList();

            return result;
        }
    }
}
