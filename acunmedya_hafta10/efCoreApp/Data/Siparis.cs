using System.ComponentModel.DataAnnotations;
namespace efCoreApp.Data
{
 public class Siparis
    {
        [Key]
        public int? SiparisId { get; set; }
        public int? MusteriId { get; set; } 
        public int? UrunId { get; set; }
        public DateTime? SiparisTarihi { get; set; }
        public decimal? ToplamTutar { get; set; }
        public string Durum { get; set; } = string.Empty;
        public  Urun? Urun { get; set; }
        public  Musteri? Musteri { get; set; }
        
    }
}