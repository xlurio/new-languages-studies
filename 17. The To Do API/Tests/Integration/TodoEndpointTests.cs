namespace ToDoAPITests.Integration;

using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using ToDoAPI;
using ToDoAPITests.TestHelpers;
using ToDoAPI.Services;
using ToDoAPI.Models;
using ToDoAPI.Controllers;
using Microsoft.AspNetCore.Mvc;

struct PostRequestArrangements
{
  public string Title { get; }
  public string Deadline { get; }

  public PostRequestArrangements(string title, string deadline)
  {
    Title = title;
    Deadline = deadline;
  }
}

[TestFixture]
public class TodoEndpointTests
{
  private ToDoController _controller;
  private IUnitOfWork _unitOfWork;

  [SetUp]
  public void SetUp()
  {
    DateTime task1Deadline = new DateTime(2022, 07, 22);
    ToDoTask task1 = 
      new ToDoTask("Talk to the college atendant", task1Deadline);

    List<IModel> taskObjects = new List<IModel>{
      task1
    };

    _unitOfWork = new FakeUnitOfWork(taskObjects);
    _controller = new ToDoController(_unitOfWork);
  }

  [Test]
  public void CreateTask()
  {
    PostRequestArrangements arrangements = GivenThePostRequest();
    WhenEndpointIsPostRequested(arrangements);
    ThenShouldCreateTask();
  }

  private PostRequestArrangements GivenThePostRequest()
  {
    string title = "Register to college";
    string deadline = "2022-07-27";

    return new PostRequestArrangements(
      title, deadline
    );
  }

  private void WhenEndpointIsPostRequested(
    PostRequestArrangements arrangements
  )
  {
    string title = arrangements.Title;
    string deadline = arrangements.Deadline;
    ActionResult result = _controller.CreateTask(title, deadline);
  }

  private void ThenShouldCreateTask(){

    List<IModel> result = _unitOfWork.ToDoTaskObjects.Get();
    int numberOfObjects = result.Count;

    ToDoTask objectCreated = result.Last() as ToDoTask;

    Assert.That(numberOfObjects, Is.EqualTo(2));
    Assert.That(objectCreated.Title, Is.EqualTo("Register to college"));
  }
}