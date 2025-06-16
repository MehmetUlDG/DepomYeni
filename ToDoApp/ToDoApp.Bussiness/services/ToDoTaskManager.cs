using ToDoApp.Entities;
using ToDoApp.DataAccess;
using System.Threading.Tasks;

namespace ToDoApp.Bussiness
{
    public class ToDoTaskManager : IToDoTaskService
    {
        private readonly IToDoTaskRepository _repo;
        private readonly IGoogleCalendarService _googleService;
        public ToDoTaskManager(IToDoTaskRepository repo,IGoogleCalendarService googleService)
        {
            _repo = repo;
            _googleService = googleService;
        }

    

        public async Task AddTaskAsync(ToDoTask task,ToDoUser user)
        {
             if (task == null)
            {
                throw new ArgumentNullException(nameof(task), "Task cannot be null");
            }
            if (await _googleService.IsGoogleLinkedAsync(user))
            {
                var googleEventId = await _googleService.AddTaskGoogleEventAsync(task, user);
                task.GoogleEventId = googleEventId;
            }
           await _repo.AddTaskAsync(task);
           await _repo.SaveChangesAsync();
        }

        public  async Task DeleteTask(int id, ToDoUser user)
        {
            var task = _repo.GetTaskById(id);
            if (task==null)
            {
                throw new ArgumentException("Invalid task ID", nameof(id));
            }
            if (await _googleService.IsGoogleLinkedAsync(user) && !string.IsNullOrEmpty(task.GoogleEventId))
            {
                await _googleService.DeleteTaskGoogleEventAsync(task, user);
         }
           await _repo.DeleteTaskAsync(id);
        }

        public List<ToDoTask> GetAllTasks()
        {
            return _repo.GetAllTasks();
        }

        public ToDoTask? GetTaskByGoogleEventId(string googleEventId)
        {
            if (string.IsNullOrWhiteSpace(googleEventId))
            {
                throw new ArgumentException("Google Event ID cannot be null or empty", nameof(googleEventId));
            }
            return _repo.GetTaskByGoogleEventId(googleEventId);
        }

        public ToDoTask? GetTaskById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Böyle bir Id bulunamadı.", nameof(id));
            }
            return _repo.GetTaskById(id);
        }


        public List<ToDoTask> GetTasksByUserId(int userId)
        {
            if (userId <= 0)
            {
                throw new ArgumentException("Invalid user ID", nameof(userId));
            }
            return _repo.GetTasksByUserId(userId);
        }

        

        public async Task UpdateTask(ToDoTask task, ToDoUser user)
        {
             var existingTask = _repo.GetTaskById(task.Id);
            if (existingTask == null)
            {
                throw new ArgumentException("Task not found", nameof(task));
            }
            if (await _googleService.IsGoogleLinkedAsync(user))
            {
                if (!string.IsNullOrEmpty(existingTask.GoogleEventId))
                {
                    var updatedGoogleEventId = await _googleService.UpdateTaskGoogleEventAsync(task, user);
                    existingTask.GoogleEventId = updatedGoogleEventId;
                }
                else
                {
                    var newGoogleEventId = await _googleService.AddTaskGoogleEventAsync(task, user);
                    existingTask.GoogleEventId = newGoogleEventId;
                }
            }
            existingTask.Title = task.Title;
            existingTask.Description = task.Description;
            existingTask.CompletedAt = task.CompletedAt;
            existingTask.IsCompleted = task.IsCompleted;
            existingTask.GoogleEventId = task.GoogleEventId;
            
           await _repo.UpdateTaskAsync(existingTask);
           await _repo.SaveChangesAsync();
        }
    }
}