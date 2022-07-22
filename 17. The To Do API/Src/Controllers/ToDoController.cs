namespace ToDoAPI.Controllers;

using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoAPI.Models;
using ToDoAPI.Services;

[ApiController]
[Route("api/[controller]")]
public class ToDoController : ControllerBase
{
  public IUnitOfWork Uow { get; }
  public ToDoController(IUnitOfWork unitOfWork)
  {
    Uow = unitOfWork;
  }

  [HttpGet(Name="GetTasks")]
  public ActionResult GetTasks()
  {
    return Ok(Uow.ToDoTaskObjects.Get());
  }

  [HttpPost(Name="CreateTask")]
  public ActionResult CreateTask(
    [FromBody] string title, [FromBody] string deadline
  )
  {
    DateTime parsedDeadline = ParseDeadline(deadline);

    ToDoTask task = new ToDoTask(title, parsedDeadline);
    Uow.ToDoTaskObjects.Add(task);
    Uow.Commit();
    
    return Ok(Uow.ToDoTaskObjects.Get());
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