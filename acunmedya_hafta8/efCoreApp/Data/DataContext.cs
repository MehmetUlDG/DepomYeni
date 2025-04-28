using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
namespace efCoreApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }


        public DbSet<Musteri> Musteriler => Set<Musteri>();
        public DbSet<Urun> Urunler => Set<Urun>();
        public DbSet<Siparis> Siparisler => Set<Siparis>();



    }
}