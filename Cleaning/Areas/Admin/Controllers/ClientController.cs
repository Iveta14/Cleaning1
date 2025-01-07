using Cleaning.Entities;
using Cleaning.Helpers;
using Cleaning.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cleaning.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = StaticData.Role_Admin)] //потребител само с тази роля може да достъпи
    public class ClientController : Controller
    {
        private IUserService _userService;
        public ClientController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            List<ApplicationUser> clientList = _userService.GetClientList();
            return View(clientList);
        }
    }
}
