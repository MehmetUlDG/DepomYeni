namespace ToDoApp.Entities.Dto
{
    public class TaskDetailsDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; }= DateTime.UtcNow;
        public DateTime? CompletedAt { get; set; }
        public int UserId { get; set; }
        public string? GoogleEventId { get; set; }
    }
}