namespace Cleaning.Entities
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ThumbnailImagePath { get; set; }
        public string PhotoBeforePath { get; set; }
        public string PhotoAfterPath { get; set; }
        public ICollection<OrderService> OrderServices { get; } = [];
        //public ICollection<Order> Orders { get; } = [];
    }
}
