using Cleaning.Enums;

namespace Cleaning.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public ApplicationUser Client { get; set; } = null;
        public int EmployeeId { get; set; }
        public ApplicationUser Employee { get; set; } = null;
        public DateTime DateAndTime { get; set; }
        public int OrderStatus { get; set; }
        public decimal Price { get; set; }
        public List<OrderService> OrderServices { get; set; } = [];
        public List<Service> Services { get; } = [];
    }
}
