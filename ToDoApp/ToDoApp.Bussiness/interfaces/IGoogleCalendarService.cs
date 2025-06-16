using ToDoApp.Entities;
namespace ToDoApp.Bussiness
{
    public interface IGoogleCalendarService
    {
        /// <summary>
        /// Google Calendar Uygulamasına API ile bağlanarak kullanıcının takvimine etkinlik ekler.
        /// </summary>
        /// <param name="task">Görev entity'sinden bir nesnedir. Takvime eklenecek etkinliği temsil eder.</param>
        /// <param name="user">Kullanıcı entity'sinden bir nesnedir. Etkinliğin ekleneceği kullanıcıyı temsil eder.</param>
        /// <returns> Oluşturulan etkinliğin Google Calendar Event ID'si.</returns>


        Task<string> AddTaskGoogleEventAsync(ToDoTask task, ToDoUser user);

        /// <summary>
        /// Google Calendar Uygulamasına API ile bağlanarak kullanıcının takvimindeki etkinliği günceller.
        /// </summary>
        /// <param name="task"> Görev entity'sinden bir nesnedir. Takvimde güncellenecek etkinliği temsil eder.</param>
        /// <param name="user">Kullanıcı entity'sinden bir nesnedir. Etkinliğin güncelleneceği kullanıcıyı temsil eder.</param>
        /// <returns> Güncellenen etkinliğin Google Calendar Event ID'si.</returns>
       
        Task<string> UpdateTaskGoogleEventAsync(ToDoTask task, ToDoUser user);

        /// <summary>
        /// Google Calendar Uygulamasına API ile bağlanarak kullanıcının takvimindeki etkinliği siler.
        /// </summary>
        ///  <param name="task">Görev entity'sinden bir nesnedir. Takvimde silinecek etkinliği temsil eder.</param>
        /// <param name="user">Kullanıcı entity'sinden bir nesnedir. Etkinliğin ekleneceği kullanıcıyı temsil eder.</param>
        

        Task DeleteTaskGoogleEventAsync(ToDoTask task, ToDoUser user);

        /// <summary>
        /// Google OAuth API ile bağlanarak kullanıcının uygulamaya bağlı olup olmadığını kontrol eder.
        /// </summary>
        /// <param name="user">Kullanıcı entity'sinden bir nesnedir. Etkinlik senkronizasyonu için kullanıcıyı temsil eder.</param>
        /// <returns> Bool(true/false) değer döndürür.</returns>
       
        Task<bool> IsGoogleLinkedAsync(ToDoUser user);

    }
}