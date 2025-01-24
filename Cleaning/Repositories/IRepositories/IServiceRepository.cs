using Cleaning.Entities;

namespace Cleaning.Repositories.IRepositories
{
    public interface IServiceRepository
    {
        public List<Service> GetServiceList();
        public bool Add(Service service);
        public Service? FindByName(string? name);
    }
}
