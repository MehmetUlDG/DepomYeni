using ToDoApp.Entities;
namespace ToDoApp.DataAccess
{
    public class ToDoTaskRepository : IToDoTaskRepository
    {
        private readonly DataContext _context;

        public ToDoTaskRepository(DataContext context)
        {
            _context = context;
        }


        public async Task AddTaskAsync(ToDoTask task)
        {
            if (task == null)
            {
                throw new ArgumentNullException(nameof(task), "Görevini boş bırakamazsın");
            }
            if (string.IsNullOrWhiteSpace(task.Title))
            {
                throw new ArgumentException("Görev başlığı boş bırakılamaz", nameof(task));
            }
            await _context.ToDoTasks.AddAsync(task);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTaskAsync(int id)
        {
            var todoTask = _context.ToDoTasks.Find(id);
            if (todoTask == null)
            {
                throw new KeyNotFoundException($"Görev ID {id} bulunamadı");
            }
            _context.ToDoTasks.Remove(todoTask);
            await _context.SaveChangesAsync();
        }

        public List<ToDoTask> GetAllTasks()
        {
            return _context.ToDoTasks.ToList();
        }
        public ToDoTask? GetTaskByGoogleEventId(string googleEventId)
        {
            if (string.IsNullOrWhiteSpace(googleEventId))
            {
                throw new ArgumentException("Google etkinlik ID'si boş bırakılamaz", nameof(googleEventId));
            }
            return _context.ToDoTasks.FirstOrDefault(t => t.GoogleEventId == googleEventId);
        }

        public ToDoTask? GetTaskById(int id)
        {
            return _context.ToDoTasks.Find(id);
        }

        public List<ToDoTask> GetTasksByUserId(int userId)
        {
            return _context.ToDoTasks.Where(t => t.UserId == userId).ToList();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }


        public async Task UpdateTaskAsync(ToDoTask task)
        {
            var existingTask = _context.ToDoTasks.Find(task.Id);
            if (existingTask == null)
            {
                throw new KeyNotFoundException($"Görev ID {task.Id} bulunamadı");
            }
            existingTask.Title = task.Title;
            existingTask.Description = task.Description;
            existingTask.IsCompleted = task.IsCompleted;
            existingTask.CompletedAt = task.CompletedAt;

            _context.ToDoTasks.Update(existingTask);
            await _context.SaveChangesAsync();
        }
    }
}