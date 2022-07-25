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

  [HttpGet("{id}")]
  public ActionResult GetTaskById(int id)
  {
    return Ok(Uow.ToDoTaskObjects.Get(id));
  }

  [HttpPost(Name="CreateTask")]
  public ActionResult CreateTask(
    ToDoTask task
  )
  {
    Uow.ToDoTaskObjects.Add(task);
    Uow.Commit();
    
    return Ok(Uow.ToDoTaskObjects.Get());
  }

  [HttpPut("{id}")]
  public ActionResult ReplaceTask(int id, ToDoTask task)
  {
    ToDoTask taskToReplace = (Uow.ToDoTaskObjects.Get(id) as ToDoTask)!;
    taskToReplace.Title = task.Title;
    taskToReplace.Deadline = task.Deadline;

    Uow.Commit();
    return Ok(taskToReplace);
  }
}