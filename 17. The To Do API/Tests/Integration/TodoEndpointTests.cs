namespace ToDoAPITests.Integration;

using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using ToDoAPI;
using ToDoAPITests.TestHelpers;
using ToDoAPI.Services;
using ToDoAPI.Models;

[TestFixture]
public class TodoEndpointTests
{
  private HttpClient _controller;

  [SetUp]
  public void SetUp()
  {
    DateTime task1Deadline = new DateTime(2022, 07, 22);
    ToDoTask task1 = 
      new ToDoTask("Talk to the college atendant", task1Deadline);

    List<ToDoTask> taskObjects = new List<ToDoTask>{
      task1
    };

    IUnitOfWork Uow = new FakeUnitOfWork(taskObjects);
    _controller = new GreetingsControllerTests(Uow);
  }

  [Test]
  public async Task CreateTask()
  {
    string arrangements = GivenThePostRequest();
    string result = await WhenEndpointIsPostRequested(arrangements);
    ThenShouldCreateTask(result);
  }

  private async Task<string> GivenThePostRequest()
  {
    Dictionary<string, string> requestBodyValue =
      new Dictionary<string, string>{
        {"title", "Register to college"},
        {"deadline", "2022-07-27"}
      };
    HttpContent requestBody = new FormUrlEncodedContent(requestBodyValue);
    string bodyValue = await requestBody.ReadAsStringAsync();

    return bodyValue;
  }

  private async Task<string> WhenEndpointIsPostRequested(
    string arrangements
  )
  {
    string url = arrangements.Url;
    HttpContent requestContent = arrangements.Content;
    HttpResponseMessage response = await _client.PostAsync(url, requestContent);

    HttpContent responseBody = response.Content;
    string responseBodyValue = await responseBody.ReadAsStringAsync();

    return responseBodyValue;
  }

  private void ThenShouldCreateTask(string responseBody){
    List<string> expectedResults = new List<string>(2);
    expectedResults.Add("Register to college");
    expectedResults.Add("2022-07-27");

    foreach(string result in expectedResults)
    {
      StringAssert.Contains(result, responseBody);
    }
  }
}