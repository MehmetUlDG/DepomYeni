namespace ToDoApp.Entities.Dto
{
    public class UserAuthDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public bool IsGoogleLinked { get; set; } = false;
        public DateTime GoogleTokenExpiry { get; set; }
        public string? GoogleAccessToken { get; set; }
        public string? GoogleRefreshToken { get; set; }
      
    }
}

