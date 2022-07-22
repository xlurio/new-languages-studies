namespace ToDoAPI.Models;

public class ToDoTask
{
  public int TaskId { get; set; }
  public string Title { get; set; }
  public DateTime Deadline { get; set; }

  public ToDoTask(string title, DateTime deadline)
  {
    Title = title;
    Deadline = deadline;
  }
}