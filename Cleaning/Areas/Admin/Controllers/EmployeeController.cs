using Cleaning.Entities;
using Cleaning.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Cleaning.Areas.Admin.Controllers
{
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
    }
}
