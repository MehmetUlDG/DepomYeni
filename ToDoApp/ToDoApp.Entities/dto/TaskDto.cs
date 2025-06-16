namespace ToDoApp.Entities.Dto
{
    public class TaskDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool IsCompleted { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; 
        public DateTime? CompletedAt { get; set; } = null;
     
    }
}