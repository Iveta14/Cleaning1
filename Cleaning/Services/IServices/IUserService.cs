using Cleaning.Entities;
using Cleaning.Helpers;

namespace Cleaning.Services.IServices
{
    public interface IUserService
    {
        public void SetModelStateDictionary(IValidationDictionary modelState);
        public List<ApplicationUser> GetClientList();
        public List<ApplicationUser> GetEmployeeList();
        public bool AddEmployee(ApplicationUser employee);
    }
}
