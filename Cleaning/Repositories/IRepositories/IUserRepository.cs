using Cleaning.Entities;

namespace Cleaning.Repositories.IRepositories
{
    public interface IUserRepository
    {
        public List<ApplicationUser> GetUserListWithRole(string role);
        public bool Add(ApplicationUser user);
        public ApplicationUser? FindByUserName(string? userName);
        public bool Delete(ApplicationUser user);
    }
}
