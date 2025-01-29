using Cleaning.Entities;
using Cleaning.Helpers;
using Cleaning.Repositories.IRepositories;
using Cleaning.Services.IServices;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Cleaning.Services
{
    public class ServiceService : IServiceService
    {
        private IServiceRepository _repository;
        private ModelStateDictionary _modelState;
        private IWebHostEnvironment _webHostEnvironment;

        public ServiceService(IServiceRepository repository)
        {
            _repository = repository;
        }

        public void SetModelStateDictionary(ModelStateDictionary modelState)
        {
            _modelState = modelState;
        }

        public List<Service> GetServiceList()
        {
            return _repository.GetServiceList();
        }

        public bool ValidateService(Service service)
        {
            if (_modelState == null)
                throw new ArgumentNullException(nameof(_modelState));

            Service? service1 = _repository.FindByName(service.Name);
            if (service1 != null)
            {
                if (service.Id != service1.Id)
                    _modelState.AddModelError("", $"Услугата {service1.Name} вече съществува.");
            }

            return _modelState.IsValid;
        }

        public bool ValidateServiceOnCreate(Service service, IFormFile? file)
        {
            if (_modelState == null)
                throw new ArgumentNullException(nameof(_modelState));

            if (file == null)
                _modelState.AddModelError("", "Добавете снимка на услугата!");
            if (file != null)
            {
                string ext = System.IO.Path.GetExtension(file.FileName);
                if (ext != ".jpg")
                    _modelState.AddModelError("", "Невалиден файл! Допускат се файлове с разширение .jpg!");
            }
            return _modelState.IsValid;
        }

        public bool AddService(Service service, IFormFile? file)
        {
            try
            {
                string fileName = "";
                string filePath = "";
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                string productIamgeDirectory = StaticData.GetImagePathDir();
                string fullPath = Path.Combine(wwwRootPath, productIamgeDirectory);

                try
                {
                    if (!ValidateServiceOnCreate(service, file))
                        return false;

                    fileName = Utils.SaveFormFile(file, fullPath);
                    filePath = productIamgeDirectory + Path.DirectorySeparatorChar + fileName;
                    service.ThumbnailImagePath = filePath;

                    if (!_repository.Add(service))
                    {
                        Utils.DeleteFile(Path.Combine(wwwRootPath, filePath));
                        return false;
                    }
                    return true;
                }
                catch
                {
                    if (!String.IsNullOrEmpty(fullPath))
                        Utils.DeleteFile(Path.Combine(wwwRootPath, filePath));
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
