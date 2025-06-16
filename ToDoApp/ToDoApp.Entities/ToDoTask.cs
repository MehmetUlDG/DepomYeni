using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Entities
{
    public class ToDoTask
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsCompleted { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? CompletedAt { get; set; } = null;

        public string? GoogleEventId { get; set; } = null;
    }
}