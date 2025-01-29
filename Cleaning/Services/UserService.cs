using Cleaning.Entities;
using Cleaning.Helpers;
using Cleaning.Repositories.IRepositories;
using Cleaning.Services.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Data;
using System.Text.RegularExpressions;

namespace Cleaning.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _repository;
        UserManager<ApplicationUser> _userManager;
        private ModelStateDictionary _modelState;

        public UserService(IUserRepository repository, UserManager<ApplicationUser> userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }

        public void SetModelStateDictionary(ModelStateDictionary modelState)
        {
            _modelState = modelState;
        }

        public List<ApplicationUser> GetClientList()
        {
            return _repository.GetUserListWithRole(StaticData.Role_Client);
        }

        public List<ApplicationUser> GetEmployeeList()
        {
            return _repository.GetUserListWithRole(StaticData.Role_Employee);
        }


        public bool ValidateEmployee(ApplicationUser employee)
        {
            if (_modelState == null)
                throw new ArgumentNullException(nameof(_modelState));

            ApplicationUser? employee1 = _repository.FindByUserName(employee.UserName);
            if (employee1 != null)
            {
                if (employee.Id != employee1.Id)
                    _modelState.AddModelError("", $"Потребителят {employee1.UserName} вече съществува.");
            }

            return _modelState.IsValid;
        }

        public bool AddEmployee(ApplicationUser employee)
        {
            try
            {
                if (!ValidateEmployee(employee))
                    return false;
                var userResult = _userManager.CreateAsync(employee, employee.PasswordHash).GetAwaiter().GetResult();
                var roleResult = _userManager.AddToRoleAsync(employee, StaticData.Role_Employee).GetAwaiter().GetResult();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteUser(string id)
        {
            ApplicationUser user = _userManager.FindByIdAsync(id).GetAwaiter().GetResult();
            _repository.Delete(user);
            return true;
        }
    }
}
