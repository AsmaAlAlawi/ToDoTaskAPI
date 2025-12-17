using Microsoft.EntityFrameworkCore;
using System.Reflection;
using ToDoTaskAPI.Models;

namespace ToDoTaskAPI.Context
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

    }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<TodoTask> ToDoTasks { get; set; }
        public DbSet<TaskCategory> TaskCategories { get; set; }

    }
}
