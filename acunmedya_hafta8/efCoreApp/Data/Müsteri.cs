using System.ComponentModel.DataAnnotations;

namespace efCoreApp.Data
    {
        public class Müsteri
        {   [Key]
            public int Id { get; set; }
            public string Ad { get; set; }= string.Empty;
            public string Soyad { get; set; }= string.Empty;
            public string Email { get; set; }= string.Empty;
            public string Telefon { get; set; }= string.Empty;
            public DateTime DogumTarihi { get; set; }
            public string Adres { get; set; }= string.Empty;
        }
    }