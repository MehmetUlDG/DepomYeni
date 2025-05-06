using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace efCoreApp.Data
{
   

public class Siparis
{
    [Key]
    public int SiparisId { get; set; }

    [Required]
    [ForeignKey("Musteri")]
    public int MusteriId { get; set; }

    [Required]
    [ForeignKey("Urun")]
    public int UrunId { get; set; }

    [Required]
    public DateTime SiparisTarihi { get; set; }

    [Range(0, double.MaxValue)]
    public decimal ToplamTutar { get; set; }

    [Required]
    public string Durum { get; set; } = string.Empty;

    public Urun? Urun { get; set; }
    public Musteri? Musteri { get; set; }
}
}