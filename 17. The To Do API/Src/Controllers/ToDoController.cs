namespace ToDoAPI.Controllers;

using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoAPI.Models;
using ToDoAPI.Services;
using ToDoAPI.Exceptions;
using ToDoAPI.Adapters;
using Microsoft.AspNetCore.JsonPatch;
using ToDoAPI.Filters;

[ApiController]
[Route("api/[controller]")]
public class ToDoController : ControllerBase
{
  private IUnitOfWork _unitOfWork;
  public ToDoController(IUnitOfWork unitOfWork)
  {
    _unitOfWork = unitOfWork;
  }

  [HttpGet(Name="GetTasks")]
  public ActionResult GetTasks([FromQuery] ToDoTaskFilter filter)
  {
    try
    {
      List<IModel> tasks = _unitOfWork.ToDoTaskObjects.Filter(filter);
      return Ok(tasks);

    } catch (TaskNotFoundException) {
      return BadRequest("Unexpected request");

    }
  }

  [HttpGet("{id}")]
  public ActionResult GetTaskById([FromRoute] int id)
  {
    try {
      return Ok(_unitOfWork.ToDoTaskObjects.Get(id));

    } catch (TaskNotFoundException) {
      return NotFound($"No task found with the reference {id}");

    }
  }

  [HttpPost]
  public ActionResult CreateTask(
    ToDoTask task
  )
  {
    _unitOfWork.ToDoTaskObjects.Add(task);
    _unitOfWork.Commit();

    return CreatedAtAction(
      nameof(GetTaskById), new { id = task.TaskId }, task
    );
  }

  [HttpPut("{id}")]
  public ActionResult ReplaceTask([FromRoute] int id, [FromBody]ToDoTask task)
  {
    try {
      _unitOfWork.ToDoTaskObjects.Replace(id, task);
      _unitOfWork.Commit();
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
      _unitOfWork.ToDoTaskObjects.Update(id, task);
      _unitOfWork.Commit();
      return NoContent();

    } catch (TaskNotFoundException) {
      return NotFound($"No task found with the reference {id}");

    }
  }

  [HttpDelete("{id}")]
  public ActionResult DeleteTask([FromRoute] int id)
  {
    try {
      _unitOfWork.ToDoTaskObjects.Remove(id);
      _unitOfWork.Commit();

      return Ok($"Task with id {id} was deleted");

    } catch (TaskNotFoundException) {
      return NotFound($"No task found with the reference {id}");

    }
  }
}