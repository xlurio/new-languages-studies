namespace ToDoAPI.Models;

using System.ComponentModel.DataAnnotations.Schema;

[Table("ToDoTasks")]
public class ToDoTask : IModel
{
  public int TaskId { get; set; }
  public string Title { get; set; }
  public DateTime? Deadline { get; set; }

  public ToDoTask(string title, DateTime deadline)
  {
    Random random = new Random();
    TaskId = random.Next(0,1000);
    
    Title = title;
    
    Deadline = deadline;
  }

  public ToDoTask(string title, string deadline)
  {
    Random random = new Random();
    TaskId = random.Next(0,1000);
    
    Title = title;
    
    Deadline = ParseDeadline(deadline);
  }

  private DateTime ParseDeadline(string deadlineToParse)
  {
    string dateFormat = "yyyy-MM-dd";
    DateTime parsedDeadline = DateTime.ParseExact(
      deadlineToParse, dateFormat, null
    );

    return parsedDeadline;
  }
}