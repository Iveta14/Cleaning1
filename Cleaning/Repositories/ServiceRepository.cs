using Cleaning.Data;
using Cleaning.Entities;
using Cleaning.Repositories.IRepositories;

namespace Cleaning.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly ApplicationDbContext _context;
        public ServiceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Service> GetServiceList()
        {
            return _context.Services.ToList();
        }

        public bool Add(Service service)
        {
            try
            {
                _context.Services.Add(service);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Service? FindByName(string? name)
        {
            if (String.IsNullOrEmpty(name))
                return null;
            return _context.Services.Where(s => s.Name == name).FirstOrDefault();
        }
    }
}
