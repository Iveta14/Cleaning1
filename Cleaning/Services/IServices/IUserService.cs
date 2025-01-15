using Cleaning.Entities;

namespace Cleaning.Services.IServices
{
    public interface IUserService
    {
        public List<ApplicationUser> GetClientList();
        public List<ApplicationUser> GetEmployeeList();
        public bool AddEmployee(ApplicationUser employee);
    }
}
