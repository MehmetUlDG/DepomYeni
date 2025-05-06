using System.ComponentModel.DataAnnotations;
namespace efCoreApp.Data
{
    public class Musteri
    {
        [Key]
        public int? MusteriId { get; set; }
        public string Ad { get; set; } = string.Empty;
        public string Soyad { get; set; } = string.Empty;
        public string AdSoyad => $"{Ad} {Soyad}";
        public string Email { get; set; } = string.Empty;
        public string Telefon { get; set; } = string.Empty;
        public DateTime? DogumTarihi { get; set; }
        public string Adres { get; set; } = string.Empty;
        public ICollection<Siparis>? Siparisler { get; set; } = new List<Siparis>();
    }
}