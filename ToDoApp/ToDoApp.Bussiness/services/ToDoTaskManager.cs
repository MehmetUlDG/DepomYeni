using ToDoApp.Entities;
using ToDoApp.DataAccess;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ToDoApp.Bussiness
{
    public class ToDoTaskManager : IToDoTaskService
    {
        private readonly IToDoTaskRepository _repo;

        public ToDoTaskManager(IToDoTaskRepository repo)
        {
            _repo = repo;
        }



        public async Task AddTaskAsync(ToDoTask task, ToDoUser user)
        {
            if (task == null)
            {
                throw new ArgumentNullException(nameof(task), "Task cannot be null");
            }

            await _repo.AddTaskAsync(task);
            await _repo.SaveChangesAsync();
        }

        public async Task<bool> DeleteTask(int id)
        {
            try
            {
                var task =  _repo.GetTaskById(id);
                if (task == null)
                {  
                    return false;
                }

                await _repo.DeleteTaskAsync(id);
                return true;
            }
            catch (KeyNotFoundException)
            {
                return false;
            }
            catch (DbUpdateConcurrencyException )
            {
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception($"Silme işlemi başarısız: {ex.Message}");
            }
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

            var task = _repo.GetTaskById(id);
            if (task == null)
            {
                throw new KeyNotFoundException($"ID'si {id} olan görev bulunamadı");
            }
            return task;
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