namespace ToDoAPI.Adapters;

using ToDoAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

public class ToDoContext : DbContext
{
    public DbSet<ToDoTask> ToDoTasks { get; set; }

    public ToDoContext(DbContextOptions<ToDoContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ToDoTask>().HasKey(t => t.TaskId);
    }
}