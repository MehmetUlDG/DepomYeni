using Microsoft.EntityFrameworkCore;
using ToDoApp.Entities;

namespace ToDoApp.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<ToDoTask> ToDoTasks { get; set; } = null!;
        public DbSet<ToDoUser> ToDoUsers { get; set; } = null!;
    }
}