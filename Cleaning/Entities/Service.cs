namespace Cleaning.Entities
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string ThumbnailImagePath { get; set; }
        public string PhotoBeforePath { get; set; }
        public string PhotoAfterPath { get; set; }
        public List<OrderService> OrderServices { get; } = [];
        public List<Order> Orders { get; } = [];
    }
}
