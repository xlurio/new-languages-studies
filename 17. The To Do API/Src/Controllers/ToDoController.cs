namespace ToDoAPI.Controllers;

using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoAPI.Models;

[ApiController]
[Route("api/[controller]")]
public class ToDoController : ControllerBase
{
  [HttpPost(Name="CreateTask")]
  public ActionResult CreateTask()
  {
    string title = Request.Form["title"];

    string deadline = Request.Form["deadline"];
    DateTime parsedDeadline = ParseDeadline(deadline);

    ToDoTask task = new ToDoTask(title, parsedDeadline);
    return Ok(task);
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