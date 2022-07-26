namespace ToDoAPI.Adapters;

using Microsoft.EntityFrameworkCore;
using ToDoAPI.Models;
using Microsoft.AspNetCore.JsonPatch;

public class TaskRepository : IRepository
{
  private DbContext _context;

  public TaskRepository(DbContext context)
  {
    _context = context;
  }

  public void Add(IModel objectToAdd)
  {
    _context.Add(objectToAdd);
  }

  public List<IModel> Get()
  {
    IEnumerable<IModel> objectsQuery =
      from task in (_context as ToDoContext)!.ToDoTasks
      orderby task.TaskId ascending
      select task;

    return objectsQuery.ToList();
  }

  public IModel Get(int reference)
  {
    IEnumerable<IModel> objectsQuery =
      from task in (_context as ToDoContext)!.ToDoTasks
      where task.TaskId == reference
      select task;

    return objectsQuery.First();
  }

  public void Replace(int reference, IModel updatedObject)
  {
    ToDoTask foundTask = (Get(reference) as ToDoTask)!;
    ToDoTask updatedTask = (updatedObject as ToDoTask)!;

    foundTask.Title = updatedTask.Title;
    foundTask.Deadline = updatedTask.Deadline;
  }

  public void Update(int reference, JsonPatchDocument newData)
  {
    ToDoTask foundObject = (Get(reference) as ToDoTask)!;
    newData.ApplyTo(foundObject);
  }

  public void Remove(int reference)
  {
    ToDoTask foundTask = (Get(reference) as ToDoTask)!;
    _context.Remove(foundTask);
  }
}