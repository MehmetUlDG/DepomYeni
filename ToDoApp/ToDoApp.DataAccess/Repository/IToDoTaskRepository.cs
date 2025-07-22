using ToDoApp.Entities;
namespace ToDoApp.DataAccess
{
    public interface IToDoTaskRepository
    {
        /// <summary>
        /// Veritabanından bütün etkinlikleri getirir.
        /// </summary>
        /// <returns> DbContext üzerinden bütün etkinlikleri listeler.</returns>
        List<ToDoTask> GetAllTasks();
        /// <summary>
        /// Belirtilen id değerine göre etkinliği veritabanından getirir.
        /// </summary>
        /// <param name="id"> ToDoTask entitisindeki Id değişkenine karşılık gelir.</param>
        /// <returns> DbContext üzerinden belirtilen id değerini Find metodu ile çeker ve bu değeri döndürür.</returns>
        ToDoTask? GetTaskById(int id);
        /// <summary>
        /// ToDoTask entitisinden task adlı nesne oluşturulur ve veritabanına eklenir.
        /// </summary>
        /// <param name="task">ToDoTask entitisinden oluşturulan nesnenin adıdır. </param>
        /// <returns> DbContext üzerinden Add metodu ile veritabanına ekleme yapar.Herhangi bir değer döndürmez.</returns>
        Task AddTaskAsync(ToDoTask task);
        /// <summary>
        /// Oluşturulmuş bir etkinliği günceller.
        /// </summary>
        /// <param name="task">ToDoTask entitisinden oluşturulan nesnenin adıdır.Etkinlik bilgilerinin getirilmesinde ve kullanılmasında yardımcı olur.</param>
        Task UpdateTaskAsync(ToDoTask task);
        /// <summary>
        /// İstenilen id değerine göre etkinliği siler.
        /// </summary>
        /// <param name="id">ToDoTask entitisindeki Id değişkenine karşılık gelir.</param>
        Task DeleteTaskAsync(int id);
        /// <summary>
        /// Kaydedilen bilgilerin veritabanına kaydedilmesini sağlar.
        /// </summary>
        /// <returns>DbContext üzerinden SaveChangesAsync metodunu çalıştırarak veritabanına kaydetme işlemini yapar.Herhangi bir değer döndürmez.</returns>
        Task SaveChangesAsync();
        /// <summary>
        /// Belirtilen googleEventId 'ye göre etkinliği getirir.
        /// </summary>
        /// <param name="googleEventId"> ToDoTask entitisindeki GoogleEventId ye karşılık gelir.</param>
        /// <returns> DbContext üzerinden FirstOrDefault metodunu kullanarak veritabanından arama yapar ve bu değeri döndürür.</returns>
        ToDoTask? GetTaskByGoogleEventId(string googleEventId);
        /// <summary>
        ///  GoogleEventeId'si girilen etkinlikleri listeler.
        /// </summary>
        /// <param name="userId"> ToDoTask entitisindeki UserId ye karşılık gelir.</param>
        /// <returns> DbContext üzerinden Where metodunu kullanarak veritabanından listeleme yapar ve bu değeri döndürür.</returns>
        List<ToDoTask> GetTasksByUserId(int userId);
    }
}
