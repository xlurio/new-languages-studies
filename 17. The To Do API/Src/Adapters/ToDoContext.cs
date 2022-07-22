namespace ToDoAPI.Adapters;

using ToDoAPI.Models;
using System.Data.Entity;

public class ToDoContext : DbContext
{
    DbSet<ToDoTask> ToDoTasks { get; set; }
}