namespace Cleaning.Entities
{
    public class OrderService
    {
        public int OrderId { get; set; }
        public Order Order { get; set; } = null;
        public int ServiceId { get; set; }
        public Service Service { get; set; } = null;
        public int Rating { get; set; }
    }
}