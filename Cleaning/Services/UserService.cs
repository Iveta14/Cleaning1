using Cleaning.Entities;
using Cleaning.Helpers;
using Cleaning.Repositories.IRepositories;
using Cleaning.Services.IServices;

namespace Cleaning.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public List<ApplicationUser> GetClientList()
        {
            return _repository.GetUserListWithRole(StaticData.Role_Client);
        }

        public List<ApplicationUser> GetEmployeeList()
        {
            return _repository.GetUserListWithRole(StaticData.Role_Employee);
        }
    }
}
