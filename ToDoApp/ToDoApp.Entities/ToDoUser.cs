using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Entities
{
    public class ToDoUser
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Bu alan gereklidir.")]
        [StringLength(50, ErrorMessage = "İsim 50 karakterden uzun olamaz.")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Bu alan gereklidir.")]
        [StringLength(50, ErrorMessage = "Soyisim 50 karakterden uzun olamaz.")]
        public string Surname { get; set; } = string.Empty;
        [Required(ErrorMessage = "Bu alan gereklidir.")]
        [EmailAddress(ErrorMessage = "Geçersiz e-posta adresi.")]
        public string Email { get; set; } = string.Empty;
        public byte[] PasswordHash { get;  set; } = Array.Empty<byte>();
        public byte[] PasswordSalt { get;  set; } = Array.Empty<byte>();
        public bool IsGoogleLinked { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? LastLoginAt { get; set; } = null;
        public string? GoogleAccessToken { get; set; } = null;
        public string? GoogleRefreshToken { get; set; } = null;
        public DateTime? GoogleTokenExpiry { get; set; } = null;
    }
}