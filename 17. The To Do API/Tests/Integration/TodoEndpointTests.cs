namespace ToDoAPITests.Integration;

using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using ToDoAPI;
using ToDoAPITests.TestHelpers;
using ToDoAPI.Services;
using ToDoAPI.Models;
using ToDoAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using ToDoAPI.Filters;

struct PutRequestArrangements
{
  public int TaskId { get; }
  public ToDoTask NewTask { get; }

  public PutRequestArrangements (int taskId, ToDoTask newTask)
  {
    TaskId = taskId;
    NewTask = newTask;
  }
}

struct PatchRequestArrangements
{
  public int TaskId { get; }
  public JsonPatchDocument NewData { get; }

  public PatchRequestArrangements (
    int taskId, JsonPatchDocument newData
  )
  {
    TaskId = taskId;
    NewData = newData;
  }
}

[TestFixture]
public class TodoEndpointTests
{
  private ToDoController _controller;
  private IUnitOfWork _unitOfWork;
  private List<IModel> taskObjects;

  [SetUp]
  public void SetUp()
  {
    ToDoTask task1 =
      new ToDoTask("Talk to the college atendant", "2022-07-22");
    ToDoTask task2 =
      new ToDoTask("Drink water", "2022-07-25");

    taskObjects = new List<IModel>{
      task1, task2
    };

    _unitOfWork = new FakeUnitOfWork(taskObjects);
    _controller = new ToDoController(_unitOfWork);
  }

  [Test]
  public void CreateTask()
  {
    ToDoTask arrangements = GivenThePostRequest();
    WhenEndpointIsPostRequested(arrangements);
    ThenShouldCreateTask();
  }

  private ToDoTask GivenThePostRequest()
  {
    string title = "Register to college";
    string deadline = "2022-07-27";

    return new ToDoTask(
      title, deadline
    );
  }

  private void WhenEndpointIsPostRequested(
    ToDoTask arrangements
  )
  {
    ActionResult result = _controller.CreateTask(arrangements);
  }

  private void ThenShouldCreateTask(){
    List<IModel> result = _unitOfWork.ToDoTaskObjects.Get();
    int numberOfObjects = result.Count;
    int expectedNumberOfObject = taskObjects.Count;

    ToDoTask objectCreated = (result.Last() as ToDoTask)!;

    Assert.That(numberOfObjects, Is.EqualTo(expectedNumberOfObject));
    Assert.That(objectCreated.Title, Is.EqualTo("Register to college"));
    Assert.That((_unitOfWork as FakeUnitOfWork)!.Saved, Is.EqualTo(true));
  }

  [Test]
  public void GetTasks()
  {
    List<IModel> result = WhenEndpointIsGetRequested()!;
    ThenShouldRetrieveTasks(result);
  }

  private List<IModel>? WhenEndpointIsGetRequested()
  {
    ToDoTaskFilter filter = new ToDoTaskFilter();

    OkObjectResult response = (_controller.GetTasks(filter) as OkObjectResult)!;
    return (response!).Value as List<IModel>;
  }

  private void ThenShouldRetrieveTasks(List<IModel> result)
  {
    Assert.That(result.Count, Is.EqualTo(taskObjects.Count));
  }

  [Test]
  public void GetTaskById()
  {
    int arrangements = GivenTheTaskId();
    ToDoTask result = WhenEndpointIsGetRequestedWithIdParameter(arrangements)!;
    ThenShouldReturnCorrespondentTask(result, arrangements);
  }

  private int GivenTheTaskId()
  {
    ToDoTask task1 = (taskObjects[0] as ToDoTask)!;
    return task1.TaskId;
  }

  private ToDoTask? WhenEndpointIsGetRequestedWithIdParameter(
    int id
  )
  {
    OkObjectResult response = (_controller.GetTaskById(id) as OkObjectResult)!;
    return (response!).Value as ToDoTask;
  }

  private void ThenShouldReturnCorrespondentTask(ToDoTask result, int taskId)
  {
    ToDoTask expectedObject =
      (_unitOfWork.ToDoTaskObjects.Get(taskId) as ToDoTask)!;

    Assert.That(result.TaskId, Is.EqualTo(expectedObject.TaskId));
  }

  [Test]
  public void ReplaceTask()
  {
    PutRequestArrangements arrangements = GivenThePutRequest();
    WhenEndpointIsPutRequested(arrangements);
    ThenTheObjectIsReplaced(arrangements);
  }

  private PutRequestArrangements GivenThePutRequest()
  {
    ToDoTask taskToUpdate = (taskObjects[0] as ToDoTask)!;
    int taskToUpdateId = taskToUpdate.TaskId;

    ToDoTask newTask = new ToDoTask(
      "Reply Andre", "2022-07-25"
    );

    return new PutRequestArrangements(
      taskToUpdateId, newTask
    );
  }

  private void WhenEndpointIsPutRequested(PutRequestArrangements arrangements)
  {
    _controller.ReplaceTask(
      arrangements.TaskId, arrangements.NewTask
    );
  }

  private void ThenTheObjectIsReplaced(PutRequestArrangements arrangements)
  {
    int taskId = arrangements.TaskId;
    ToDoTask replacedTask =
      (_unitOfWork.ToDoTaskObjects.Get(taskId) as ToDoTask)!;

    Assert.That((_unitOfWork as FakeUnitOfWork)!.Saved, Is.EqualTo(true));
    Assert.That(replacedTask.Title, Is.EqualTo(arrangements.NewTask.Title));
  }

  [Test]
  public void ModifyTask()
  {
    PatchRequestArrangements arrangements = GivenThePatchRequest();
    WhenPatchRequested(arrangements);
    ThenTheObjectIsModified(arrangements);
  }

  private PatchRequestArrangements GivenThePatchRequest()
  {
    ToDoTask taskToChange = (taskObjects[0] as ToDoTask)!;
    JsonPatchDocument jsonObject = new JsonPatchDocument();

    string title = "End To Do API";
    jsonObject.Replace(nameof(taskToChange.Title), title);

    int taskId = taskToChange.TaskId;

    return new PatchRequestArrangements(
      taskId, jsonObject
    );
  }

  private void WhenPatchRequested(PatchRequestArrangements arrangements)
  {
    _controller.UpdateTask(arrangements.TaskId, arrangements.NewData);
  }

  private void ThenTheObjectIsModified(PatchRequestArrangements arrangements)
  {
    string expectedTitle = "End To Do API";
    ToDoTask taskUpdated =
      (_unitOfWork.ToDoTaskObjects.Get(arrangements.TaskId) as ToDoTask)!;

    Assert.That(taskUpdated.Title, Is.EqualTo(expectedTitle));
    Assert.That((_unitOfWork as FakeUnitOfWork)!.Saved, Is.EqualTo(true));
  }

  [Test]
  public void RemoveTask()
  {
    int arrangements = GivenTheTaskId();
    WhenDeleteRequested(arrangements);
    ThenObjectIsDeleted();
  }

  private void WhenDeleteRequested(int taskId)
  {
    _controller.DeleteTask(taskId);
  }

  private void ThenObjectIsDeleted()
  {
    int expectedObjectsLeft = 1;
    int result = _unitOfWork.ToDoTaskObjects.Get().Count;

    Assert.That(result, Is.EqualTo(expectedObjectsLeft));
    Assert.That((_unitOfWork as FakeUnitOfWork)!.Saved, Is.EqualTo(true));
  }

  [Test]
  public void FilterTasks()
  {
    ToDoTaskFilter arrangements = GivenTheFilter();
    List<IModel> results = WhenGetRequestedWithFilter(arrangements);
    ThenRetrieveFilteredTasks(results);
  }

  private ToDoTaskFilter GivenTheFilter()
  {
    return new ToDoTaskFilter(
      "2022-07-21", "2022-07-23"
    );
  }

  private List<IModel> WhenGetRequestedWithFilter(ToDoTaskFilter arrangements)
  {
    OkObjectResult? response =
      _controller.GetTasks(arrangements) as OkObjectResult;
    List<IModel> results = (response!.Value as List<IModel>)!;

    return results;
  }

  private void ThenRetrieveFilteredTasks(List<IModel> results)
  {
    ToDoTask expectedResult = (taskObjects[0] as ToDoTask)!;
    ToDoTask result = (results[0] as ToDoTask)!;

    Assert.That(result.Title, Is.EqualTo(expectedResult.Title));
    Assert.That(results.Count, Is.EqualTo(1));
  }
}