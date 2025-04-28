using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
namespace efCoreApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }


        public DbSet<Müsteri> Müsteriler => Set<Müsteri>();
        public DbSet<Ürün> Ürünler => Set<Ürün>();
        public DbSet<Siparis> Siparisler => Set<Siparis>();



    }
}