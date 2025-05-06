using efCoreApp.Models;
using Microsoft.EntityFrameworkCore;
namespace  efCoreApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
    {} 

        public DbSet<Musteri> Musteriler { get; set; } = null!;
        public DbSet<Urun> Urunler { get; set; } = null!;
        public DbSet<Siparis> Siparisler { get; set; } = null!;
      
      
       protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Siparis>()
        .HasOne(s => s.Musteri)
        .WithMany(m => m.Siparisler)
        .HasForeignKey(s => s.MusteriId)
        .OnDelete(DeleteBehavior.Restrict);

    modelBuilder.Entity<Siparis>()
        .HasOne(s => s.Urun)
        .WithMany()
        .HasForeignKey(s => s.UrunId)
        .OnDelete(DeleteBehavior.Restrict);


    modelBuilder.Entity<Musteri>()
        .HasMany(m => m.Siparisler)
        .WithOne(s => s.Musteri)
        .HasForeignKey(s => s.MusteriId);

    modelBuilder.Entity<Urun>()
        .HasMany(u => u.Siparisler)
        .WithOne(s => s.Urun)
        .HasForeignKey(s => s.UrunId);

}
public override int SaveChanges()
{
    var entries = ChangeTracker.Entries()
        .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

    foreach (var entry in entries)
    {
        Console.WriteLine($"Entity: {entry.Entity.GetType().Name}, State: {entry.State}");
    }
    
    return base.SaveChanges();
}
}
}



