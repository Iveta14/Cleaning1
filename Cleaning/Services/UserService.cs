using Cleaning.Entities;
using Cleaning.Helpers;
using Cleaning.Repositories.IRepositories;
using Cleaning.Services.IServices;
using System.Text.RegularExpressions;

namespace Cleaning.Services
{
    public class UserService : IUserService
    {
        private IValidationDictionary? _modelState;
        private IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public void SetModelStateDictionary(IValidationDictionary modelState)
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
                    _modelState.AddError("", $"Потребителят {employee1.UserName} вече съществува.");
            }

            return _modelState.IsValid;
        }

        public bool AddEmployee(ApplicationUser employee)
        {
            try
            {
                if (!ValidateEmployee(employee))
                    return false;
                return _repository.Add(employee);
            }
            catch
            {
                return false;
            }
        }


    }
}
