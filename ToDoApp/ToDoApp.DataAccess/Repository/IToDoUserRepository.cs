using ToDoApp.Entities;
namespace ToDoApp.DataAccess
{
    public interface IToDoUserRepository
    {
        /// <summary>
        /// Veritabanındaki tüm kullanıcıları getirir.
        /// </summary>
        /// <returns>Tüm <see cref="ToDoUser"/> nesnelerinin listesi.</returns>
        List<ToDoUser> GetAllUsers();
        /// <summary>
        /// Belirtilen ID'ye sahip kullanıcıyı getirir.
        /// </summary>
        /// <param name="id">Kullanıcının benzersiz ID'si.</param>
        /// <returns>Eşleşen <see cref="ToDoUser"/> nesnesi ya da bulunamazsa <c>null</c>.</returns>
        ToDoUser? GetUserById(int id);
        /// <summary>
        /// Belirtilen e-posta adresine sahip kullanıcıyı getirir.
        /// </summary>
        /// <param name="email">Kullanıcının e-posta adresi.</param>
        /// <returns>Eşleşen <see cref="ToDoUser"/> nesnesi ya da bulunamazsa <c>null</c>.</returns>
        ToDoUser? GetUserByEmail(string email);
        /// <summary>
        /// Google hesabı bağlantılı tüm kullanıcıları getirir.
        /// </summary>
        /// <returns>Google hesabı bağlı olan <see cref="ToDoUser"/> nesnelerinin listesi.</returns>
        List<ToDoUser> GetUsersWithGoogleLinked();

        /// <summary>
        /// Yeni bir kullanıcıyı veritabanına ekler.
        /// </summary>
        /// <param name="user">Eklenmek istenen <see cref="ToDoUser"/> nesnesi.</param>
        void AddUser(ToDoUser user);
        /// <summary>
        /// Mevcut bir kullanıcıyı günceller.
        /// </summary>
        /// <param name="user">Güncellenmek istenen <see cref="ToDoUser"/> nesnesi.</param>
        void UpdateUser(ToDoUser user);
        /// <summary>
        /// Belirtilen kullanıcıya ait Google erişim ve yenileme token'larını günceller.
        /// </summary>
        /// <param name="userId">Token'ları güncellenecek kullanıcının ID'si.</param>
        /// <param name="accessToken">Yeni erişim token'ı.</param>
        /// <param name="refreshToken">Yeni yenileme (refresh) token'ı.</param>
        /// <param name="tokenExpiry">Token'ın geçerlilik süresi (isteğe bağlı).</param>
        void UpdateGoogleTokens(int userId, string accessToken, string refreshToken, DateTime? tokenExpiry);
        /// <summary>
        /// Belirtilen ID'ye sahip kullanıcıyı veritabanından siler.
        /// </summary>
        /// <param name="id">Silinecek kullanıcının ID'si.</param>
        void DeleteUser(int id);
        /// <summary>
        /// Yapılan değişiklikleri veritabanına kaydeder.
        /// </summary>
        void SaveChanges();
    }
}