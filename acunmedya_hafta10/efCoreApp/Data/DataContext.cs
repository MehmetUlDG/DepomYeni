using efCoreApp.Models;
using Microsoft.EntityFrameworkCore;
namespace efCoreApp.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {}

        public DbSet<Urun> Urunler { get; set; } = null!;
        public DbSet<Musteri> Musteriler { get; set; } = null!; 
        public DbSet<Siparis> Siparisler { get; set; } = null!;
        
    }
}