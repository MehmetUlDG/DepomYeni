using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using ToDoApp.Entities;
namespace ToDoApp.Bussiness
{
    public class GoogleCalendarManager : IGoogleCalendarService
    {
        private CalendarService GetCalendarService(ToDoUser user)
        {
            var credential = GoogleCredential.FromAccessToken(user.GoogleAccessToken);

            return new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "ToDoApp Google Calendar Integration"
            });
        }


        public async Task<string> AddTaskGoogleEventAsync(ToDoTask task, ToDoUser user)
        {


            if (string.IsNullOrEmpty(user.GoogleAccessToken))
                throw new InvalidOperationException("Kullanıcının Google hesabı bağlı değil.");

            var credential = GoogleCredential.FromAccessToken(user.GoogleAccessToken);
            var calendarService = new CalendarService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential,
                ApplicationName = "ToDoApp"
            });
            var evenStart = task.CompletedAt ?? task.CreatedAt;
            var newEvent = new Event
            {
                Summary = task.Title,
                Description = task.Description,
                Start = new EventDateTime
                {
                    DateTimeDateTimeOffset = task.CreatedAt,
                    TimeZone = "Europe/Istanbul"
                },
                End = new EventDateTime
                {
                    DateTimeDateTimeOffset = task.CreatedAt.AddHours(1),
                    TimeZone = "Europe/Istanbul"
                }
            };

            var insertRequest = calendarService.Events.Insert(newEvent, "primary");
            var createdEvent = await insertRequest.ExecuteAsync();

            return createdEvent.Id;

        }

        public async Task DeleteTaskGoogleEventAsync(ToDoTask task, ToDoUser user)
        {
            if (string.IsNullOrEmpty(task.GoogleEventId))
                return;

            var service = GetCalendarService(user);
            await service.Events.Delete("primary", task.GoogleEventId).ExecuteAsync();
        }

        public Task<bool> IsGoogleLinkedAsync(ToDoUser user)
        {
            var isLinked = user.IsGoogleLinked &&
                           !string.IsNullOrEmpty(user.GoogleAccessToken) &&
                           user.GoogleTokenExpiry > DateTime.UtcNow;

            return Task.FromResult(isLinked);
        }


        public async Task<string> UpdateTaskGoogleEventAsync(ToDoTask task, ToDoUser user)
        {
            var service = GetCalendarService(user);

            if (string.IsNullOrEmpty(task.GoogleEventId))
                throw new ArgumentException("GoogleEventId boş olamaz.");

            var existingEvent = await service.Events.Get("primary", task.GoogleEventId).ExecuteAsync();

            existingEvent.Summary = task.Title;
            existingEvent.Description = task.Description;

            existingEvent.Start = new EventDateTime
            {
                DateTimeDateTimeOffset = task.CreatedAt,
                TimeZone = "Europe/Istanbul"
            };

            existingEvent.End = new EventDateTime
            {
                DateTimeDateTimeOffset = task.CreatedAt.AddHours(1),
                TimeZone = "Europe/Istanbul"
            };

            var updateRequest = service.Events.Update(existingEvent, "primary", task.GoogleEventId);
            var updatedEvent = await updateRequest.ExecuteAsync();

            return updatedEvent.Id;
        }
    }

}