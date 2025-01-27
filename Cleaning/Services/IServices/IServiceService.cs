using Cleaning.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Cleaning.Services.IServices
{
    public interface IServiceService
    {
        public void SetModelStateDictionary(ModelStateDictionary modelState);
        public List<Service> GetServiceList();
        public bool AddService(Service service);
    }
}
