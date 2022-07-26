namespace ToDoAPI.Adapters;

using ToDoAPI.Models;
using Microsoft.EntityFrameworkCore;

public class ToDoContext : DbContext
{
    public DbSet<ToDoTask> ToDoTasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ToDoTask>().HasKey(t => t.TaskId);
    }

    protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder
    )
    {
        // Configure database context
    }
}