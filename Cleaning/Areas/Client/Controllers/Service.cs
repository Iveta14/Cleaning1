using Microsoft.AspNetCore.Mvc;

namespace Cleaning.Areas.Client.Controllers
{
    public class Service : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
