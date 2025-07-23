using ToDoApp.Entities;
namespace ToDoApp.Bussiness
{
    public interface IToDoTaskService
    {
        /// <summary>
        /// API den gelen istek üzerine bütün etkinlikleri getirir.
        /// </summary>
        /// <returns> Repository üzerinden GetAllTasks() metodunu döndürür. </returns>
        List<ToDoTask> GetAllTasks();
        /// <summary>
        /// API den gelen istek üzerine istenen id deki etkinlik getirilir.
        /// </summary>
        /// <param name="id"> 'id' adlı parametre üzerinden eşleşen id ile ilgili etkinliği getirir. </param>
        /// <returns> Repository üzerinden GetTaskById() metodunu döndürür. </returns>
        ToDoTask? GetTaskById(int id);
        /// <summary>
        /// Belirtilen kullanıcıya ait yeni bir görev ekler ve Google Calendar'a etkinlik olarak kaydeder.
        /// </summary>
        /// <param name="task">Eklenmek istenen görev.</param>
        /// <param name="user">Görevin ekleneceği kullanıcı.</param>
        Task AddTaskAsync(ToDoTask task, ToDoUser user);
        /// <summary>
        /// Belirtilen kullanıcıya ait mevcut bir görevi günceller ve Google Calendar'daki karşılığını da düzenler.
        /// </summary>
        /// <param name="task">Güncellenmek istenen görev.</param>
        /// <param name="user">Görevi güncelleyen kullanıcı.</param>
        Task UpdateTask(ToDoTask task, ToDoUser user);
        /// <summary>
        /// Belirtilen ID'ye sahip görevi siler ve ilgili Google Calendar etkinliğini kaldırır.
        /// </summary>
        /// <param name="id">Silinmek istenen görevin benzersiz kimliği.</param>
        Task DeleteTask(int id);
        /// <summary>
        /// Google Calendar etkinlik ID'sine göre ilgili görevi getirir.
        /// </summary>
        /// <param name="googleEventId">Google Calendar etkinliğine ait ID.</param>
        /// <returns> Repository  üzerinden gelen GetTaskByGoogleEventId metodunu döndürür.</returns>
        ToDoTask? GetTaskByGoogleEventId(string googleEventId);
        /// <summary>
        /// Belirtilen kullanıcıya ait tüm görevleri getirir.
        /// </summary>
        /// <param name="userId">Görevleri getirilecek kullanıcının ID'si.</param>
        /// <returns> Repository üzerinden gelen GetTasksByUserId metodunu döndürür. </returns>
        List<ToDoTask> GetTasksByUserId(int userId);
    }
}