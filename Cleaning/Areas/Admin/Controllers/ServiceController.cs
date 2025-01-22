using Microsoft.AspNetCore.Mvc;

namespace Cleaning.Areas.Admin.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
