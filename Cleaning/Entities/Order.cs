using Cleaning.Enums;

namespace Cleaning.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string ClientId { get; set; }
        public ApplicationUser Client { get; set; } = null;
        public string EmployeeId { get; set; }
        public ApplicationUser Employee { get; set; } = null;
        public DateTime DateAndTime { get; set; }
        public int OrderStatus { get; set; }
        public decimal Price { get; set; }
        public ICollection<OrderService> OrderServices { get; } = [];
        //public ICollection<Service> Services { get; } = [];
    }
}
