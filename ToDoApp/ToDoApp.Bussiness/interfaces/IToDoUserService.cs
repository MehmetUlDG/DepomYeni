
using ToDoApp.Entities;
using ToDoApp.Entities.Dto;
namespace ToDoApp.Bussines
{
    public interface IToDoUserService
    {
        /// <summary>
        /// Api'den gelen istek üzerine tüm kullanıcıları getirir.
        /// </summary>
        /// <returns> Repository üzerinen GetAllUsers metodunu döndürür. </returns>
        List<ToDoUser> GetAllUsers();
        /// <summary>
        /// Api'den gelen istek üzerine belirtilen id parametresine sahip kullanıcı getirilir.
        /// </summary>
        /// <param name="id"> id adlı parametre tanımlanarak ToDoUser entitisindeki Id değişkenini temsil eder.</param>
        /// <returns> Repository üzerinden GetUserById metodunu döndürür. </returns>
        ToDoUser? GetUserById(int id);
        /// <summary>
        /// Api'den gelen istek üzerine belirtilen email string parametresine göre ToDoUser entitisinden eşleşen Email değişkenini getirir.
        /// </summary>
        /// <param name="email"> email string parametresine göre ToDoUser entitisinden eşleşen Email değişkenini temsil eder. </param>
        /// <returns> Repository üzerinden GetUserByEmail metodunu döndürür.</returns>
        ToDoUser? GetUserByEmail(string email);
        /// <summary>
        /// Api'den gelen istek üzerine Google-Login ile giriş yapmış kullanıcıları listeler.
        /// </summary>
        /// <returns> Repository üzerinden GetUsersWithGoogleLinked metodunu döndürür.</returns>
        List<ToDoUser> GetUsersWithGoogleLinked();
        /// <summary>
        /// Api'den gelen istek üzerine Kullanıcı ekler.
        /// </summary>
        /// <param name="user"> ToDoUser entitisinden bir nesne oluşturulur.Onu temsil eder.</param>
        void AddUser(ToDoUser user);
        /// <summary>
        /// Api'den gelen istek üzerine kullanıcı bilgilerini günceller. 
        /// </summary>
        /// <param name="user">ToDoUser entitisinden bir nesne oluşturulur.Onu temsil eder.</param>
        void UpdateUser(UserDto user);
        /// <summary>
        /// Kullanıcının geçerli access token'ı ve refresh token'ı ile yeni bir access token üretir.
        /// Gerekirse refresh token'ı da yeniler ve günceller.
        /// </summary>
        /// <param name="userId">Token yenileme işlemi yapılacak kullanıcının benzersiz kimliği.</param>
        /// <param name="accessToken">Kullanıcının mevcut access token'ı.</param>
        /// <param name="refreshToken">Kullanıcının mevcut refresh token'ı.</param>
        /// <param name="tokenExpiry">Mevcut access token'ın sona erme zamanı.</param>
        void UpdateGoogleTokens(int userId, string accessToken, string refreshToken, DateTime tokenExpiry);
        /// <summary>
        /// Api'den gelen istek üzerine kullanıcı silme işlemi yapar.
        /// </summary>
        /// <param name="id"> id adlı parametre tanımlanarak ToDoUser entitisindeki Id değişkenini temsil eder.</param>
        void DeleteUser(int id);
    }
}