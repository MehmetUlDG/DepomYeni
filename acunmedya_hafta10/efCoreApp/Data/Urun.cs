using System.ComponentModel.DataAnnotations;
namespace efCoreApp.Data
{
     public class Urun
        {
            [Key]
            public int? UrunId { get; set; }
            public string Ad { get; set; } = string.Empty;
            public string Kategori { get; set; } = string.Empty;
            public decimal? Fiyat { get; set; }
            public int? StokMiktarı { get; set; }
            public string Açıklama { get; set; } = string.Empty;
            public Guid? UrunBarkod { get; set; } 
            public ICollection<Siparis>? Siparisler { get; set; } = new List<Siparis>();
        }
}