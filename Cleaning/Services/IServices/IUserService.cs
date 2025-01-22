using Cleaning.Entities;
using Cleaning.Helpers;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Cleaning.Services.IServices
{
    public interface IUserService
    {
        public void SetModelStateDictionary(ModelStateDictionary modelState);
        public List<ApplicationUser> GetClientList();
        public List<ApplicationUser> GetEmployeeList();
        public bool AddEmployee(ApplicationUser employee);
        public bool DeleteUser(string id);
    }
}
