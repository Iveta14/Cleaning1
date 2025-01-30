using Cleaning.Entities;
using Cleaning.Helpers;
using Cleaning.Repositories.IRepositories;
using Cleaning.Services.IServices;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Cleaning.Services
{
    public class ServiceService : IServiceService
    {
        private IServiceRepository _repository;
        private ModelStateDictionary _modelState;
        private IWebHostEnvironment _webHostEnvironment;

        public ServiceService(IServiceRepository repository, IWebHostEnvironment webHostEnvironment)
        {
            _repository = repository;
            _webHostEnvironment = webHostEnvironment;
        }

        public void SetModelStateDictionary(ModelStateDictionary modelState)
        {
            _modelState = modelState;
        }

        public void validate()
        {

        }

        public List<Service> GetServiceList()
        {
            return _repository.GetServiceList();
        }

        public bool ValidateServiceName(Service service)
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

        public bool RequiredFileValidation(IFormFile? file, string textMessage)
        {
            if (_modelState == null)
                throw new ArgumentNullException(nameof(_modelState));

            if (file == null)
                _modelState.AddModelError("", textMessage);

            return _modelState.IsValid;
        }

        public bool ValidateFileExt(IFormFile? file, string textMessage)
        {
            if (_modelState == null)
                throw new ArgumentNullException(nameof(_modelState));

            if (file != null)
            {
                string ext = System.IO.Path.GetExtension(file.FileName);
                if (ext != ".jpg")
                    _modelState.AddModelError("", textMessage);
            }
            return _modelState.IsValid;
        }

        public bool AddService(
            Service service,
            IFormFile? thumbNailImage,
            IFormFile? beforeServiceImage,
            IFormFile? afterServiceImage
        )
        {
            try
            {
                string thumbNailFileName = "";
                string thumbNailFilePath = "";

                string beforeServiceFileName = "";
                string beforeServiceFilePath = "";

                string afterServiceFileName = "";
                string afterServiceFilePath = "";

                string wwwRootPath = _webHostEnvironment.WebRootPath;
                string productIamgeDirectory = StaticData.GetImagePathDir();
                string fullPath = Path.Combine(wwwRootPath, productIamgeDirectory);

                try
                {
                    bool validationFlag = false;
                    validationFlag |= !ValidateServiceName(service);
                    validationFlag |= !RequiredFileValidation(thumbNailImage, "Добави реалното съобщение!");
                    validationFlag |= !RequiredFileValidation(beforeServiceImage, "Добави реалното съобщение!");
                    validationFlag |= !RequiredFileValidation(afterServiceImage, "Добави реалното съобщение!");
                    validationFlag |= !ValidateFileExt(thumbNailImage, "Добави реалното съобщение!");
                    validationFlag |= !ValidateFileExt(beforeServiceImage, "Добави реалното съобщение!");
                    validationFlag |= !ValidateFileExt(afterServiceImage, "Добави реалното съобщение!");

                    if (validationFlag)
                        return false;

                    thumbNailFileName = Utils.SaveFormFile(thumbNailImage, fullPath);
                    thumbNailFilePath = productIamgeDirectory + Path.DirectorySeparatorChar + thumbNailFileName;
                    service.ThumbnailImagePath = thumbNailFilePath;

                    beforeServiceFileName = Utils.SaveFormFile(beforeServiceImage, fullPath);
                    beforeServiceFilePath = productIamgeDirectory + Path.DirectorySeparatorChar + beforeServiceFileName;
                    service.PhotoBeforePath = beforeServiceFilePath;

                    afterServiceFileName = Utils.SaveFormFile(afterServiceImage, fullPath);
                    afterServiceFilePath = productIamgeDirectory + Path.DirectorySeparatorChar + afterServiceFileName;
                    service.PhotoAfterPath = afterServiceFilePath;

                    if (!_repository.Add(service))
                    {
                        Utils.DeleteFile(Path.Combine(wwwRootPath, thumbNailFilePath));
                        Utils.DeleteFile(Path.Combine(wwwRootPath, beforeServiceFilePath));
                        Utils.DeleteFile(Path.Combine(wwwRootPath, afterServiceFilePath));
                        return false;
                    }
                    return true;
                }
                catch
                {
                    Utils.DeleteFile(Path.Combine(wwwRootPath, thumbNailFilePath));
                    Utils.DeleteFile(Path.Combine(wwwRootPath, beforeServiceFilePath));
                    Utils.DeleteFile(Path.Combine(wwwRootPath, afterServiceFilePath));
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
