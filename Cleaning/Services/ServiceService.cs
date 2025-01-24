using Cleaning.Entities;
using Cleaning.Helpers;
using Cleaning.Repositories.IRepositories;
using Cleaning.Services.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Cleaning.Services
{
    public class ServiceService : IServiceService
    {
        private IServiceRepository _repository;
        private ModelStateDictionary _modelState;

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

        public bool AddService(Service service)
        {
            try
            {
                if (!ValidateService(service))
                    return false;

                return _repository.Add(service);
            }
            catch
            {
                return false;
            }
        }
    }
}
