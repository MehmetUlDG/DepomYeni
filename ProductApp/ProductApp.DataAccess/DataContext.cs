    
using Microsoft.EntityFrameworkCore;
using ProductApp.Entities;
namespace ProductApp.DataAccess
{
    
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }

        public DbSet<Product> Products  => Set<Product>();
    }
}