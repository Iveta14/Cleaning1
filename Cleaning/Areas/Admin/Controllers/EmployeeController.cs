using Cleaning.Areas.Admin.ViewModels;
using Cleaning.Entities;
using Cleaning.Helpers;
using Cleaning.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Cleaning.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = StaticData.Role_Admin)] //потребител само с тази роля може да достъпи
    public class EmployeeController : Controller
    {
        private IUserService _userService;
        public EmployeeController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            List<ApplicationUser> employeeList = _userService.GetEmployeeList();
            return View(employeeList);
        }

        public IActionResult Create()
        {
            EmployeeViewModel viewModel = new EmployeeViewModel();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeViewModel viewModel)
        {
            _userService.SetModelStateDictionary(ModelState);

            ApplicationUser employee = new ApplicationUser();
            viewModel.PopulateEmployee(employee);
            if (_userService.AddEmployee(employee))
            {
                TempData["success"] = $"Служителят {employee.UserName} е добавен успешно!";
                return RedirectToAction("Index");
            }
            else if (ModelState.IsValid)
            {
                TempData["error"] = "Служителят не може да бъде добавен!";
            }

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(string id)
        {
            if (_userService.DeleteUser(id))
            {
                TempData["success"] = "Служителят е изтрит успешно!";
            }
            else
            {
                TempData["error"] = "Служителят не може да бъде изтрит!";
            }
            return RedirectToAction("Index");
        }
    }
}
