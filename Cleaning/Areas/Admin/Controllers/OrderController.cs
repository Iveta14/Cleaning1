using Microsoft.AspNetCore.Mvc;

namespace Cleaning.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
