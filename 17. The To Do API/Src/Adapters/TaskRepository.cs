namespace ToDoAPI.Adapters;

using Microsoft.EntityFrameworkCore;
using ToDoAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using ToDoAPI.Filters;
using ToDoAPI.Exceptions;

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

  public List<IModel> Filter(IFilter filter)
  {
    ToDoTaskFilter parsedFilter = (filter as ToDoTaskFilter)!;

    if (parsedFilter.FromDate == null && parsedFilter.ToDate == null)
    {
      return Get();
    }

    return FilterTasks(parsedFilter);
  }

  private List<IModel> FilterTasks(ToDoTaskFilter filter)
  {
    List<IModel> objectsQuery =
      (from task in (_context as ToDoContext)!.ToDoTasks.AsEnumerable()
      where CheckFilterOnTask(filter, task)
      select (task as IModel)!).ToList();

    if (objectsQuery.Count > 0)
    {
      return objectsQuery;
    }

    throw new TaskNotFoundException(
      "No task was found within parameters"
    );
  }

  private bool CheckFilterOnTask(ToDoTaskFilter filter, IModel objectToFilter)
  {
    DateTime? taskDeadline = GetTaskDeadline(objectToFilter);

    bool isAfterLowerBound =
      IsDateAfter(taskDeadline, filter.FromDate);

    bool isBeforeUpperBound =
      IsDateAfter(filter.ToDate, taskDeadline);

    return isAfterLowerBound && isBeforeUpperBound;
  }

  private DateTime? GetTaskDeadline(IModel taskObject)
  {
    ToDoTask task = (taskObject as ToDoTask)!;

    return task.Deadline;
  }

  private bool IsDateAfter(DateTime? dateToCheck, DateTime? dateBefore)
  {
    int dayVariation = DateTime.Compare(dateBefore!.Value, dateToCheck!.Value);
    return dayVariation <= 0;
  }
}