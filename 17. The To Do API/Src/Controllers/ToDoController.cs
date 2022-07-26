namespace ToDoAPI.Controllers;

using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoAPI.Models;
using ToDoAPI.Services;
using ToDoAPI.Exceptions;
using Microsoft.AspNetCore.JsonPatch;

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
  public ActionResult GetTaskById([FromRoute] int id)
  {
    try {
      return Ok(Uow.ToDoTaskObjects.Get(id));

    } catch (TaskNotFoundException) {
      return NotFound($"No task found with the reference {id}");

    }
  }

  [HttpPost]
  public ActionResult CreateTask(
    [FromBody] ToDoTask task
  )
  {
    Uow.ToDoTaskObjects.Add(task);
    Uow.Commit();

    return CreatedAtAction(
      nameof(GetTaskById), new { id = task.TaskId }, task
    );
  }

  [HttpPut("{id}")]
  public ActionResult ReplaceTask([FromRoute] int id, [FromBody]ToDoTask task)
  {
    try {
      Uow.ToDoTaskObjects.Replace(id, task);
      Uow.Commit();
      return NoContent();

    } catch (TaskNotFoundException) {
      return NotFound($"No task found with the reference {id}");

    }
  }

  [HttpPatch("{id}")]
  public ActionResult UpdateTask(
    [FromRoute]int id, [FromBody] JsonPatchDocument task
  )
  {
    try {
      Uow.ToDoTaskObjects.Update(id, task);
      Uow.Commit();
      return NoContent();

    } catch (TaskNotFoundException) {
      return NotFound($"No task found with the reference {id}");

    }
  }

  [HttpDelete("{id}")]
  public ActionResult DeleteTask([FromRoute] int id)
  {
    try {
      Uow.ToDoTaskObjects.Remove(id);
      Uow.Commit();

      return Ok($"Task with id {id} was deleted");

    } catch (TaskNotFoundException) {
      return NotFound($"No task found with the reference {id}");

    }
  }
}