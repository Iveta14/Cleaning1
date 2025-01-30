using Cleaning.Areas.Admin.ViewModels;
using Cleaning.Entities;
using Cleaning.Helpers;
using Cleaning.Services;
using Cleaning.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cleaning.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = StaticData.Role_Admin)] //потребител само с тази роля може да достъпи
    public class ServiceController : Controller
    {
        private IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public IActionResult Index()
        {
            List<Service> serviceList = _serviceService.GetServiceList();
            return View(serviceList);
        }

        public IActionResult Create()
        {
            ServiceViewModel viewModel = new ServiceViewModel();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(
            ServiceViewModel viewModel,
            IFormFile? thumbNailImage,
            IFormFile? beforeServiceImage,
            IFormFile? afterServiceImage
        )
        {
            _serviceService.SetModelStateDictionary(ModelState);

            Service service = new Service();
            viewModel.PopulateServiceEntity(service);
            if (_serviceService.AddService(service, thumbNailImage, beforeServiceImage, afterServiceImage))
            {
                TempData["success"] = $"Услугатас {service.Name} е добавена успешно!";
                return RedirectToAction("Index");
            }
            else if (ModelState.IsValid)
            {
                TempData["error"] = "Услугата не може да бъде добавена!";
            }

            return View(viewModel);
        }
    }
}
