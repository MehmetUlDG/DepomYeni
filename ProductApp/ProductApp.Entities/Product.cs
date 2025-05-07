
namespace ProductApp.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }= string.Empty;
        public string Category { get; set; }= string.Empty;
        public decimal Price { get; set; }
        public string Description { get; set; }= string.Empty;
        public Guid ProductGuid { get; set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}