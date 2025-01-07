using Cleaning.Entities;

namespace Cleaning.Repositories.IRepositories
{
    public interface IUserRepository
    {
        public List<ApplicationUser> GetUserListWithRole(string role);
    }
}
