namespace ToDoAPI.Adapters;

using ToDoAPI.Models;

public interface IToDoContext
{
    DbSet<ToDoTask> ToDoTasks { get; set; };
}