namespace ToDoAPITests.Integration;

using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using ToDoAPI;

struct PostRequestArrangements
{
  public string Url { get; }
  public HttpContent Content { get; }

  public PostRequestArrangements(string url, HttpContent content)
  {
    Url = url;
    Content = content;
  }
}

[TestFixture]
public class TodoEndpointTests
{
  private HttpClient _client;

  [SetUp]
  public void SetUp()
  {
    WebApplicationFactory<Program> factory =
      new WebApplicationFactory<Program>();
    _client = factory.CreateClient();
  }

  [Test]
  public async Task CreateTask()
  {
    PostRequestArrangements arrangements = GivenThePostRequest();
    string result = await WhenEndpointIsPostRequested(arrangements);
    ThenShouldCreateTask(result);
  }

  private PostRequestArrangements GivenThePostRequest()
  {
    Dictionary<string, string> requestBodyValue =
      new Dictionary<string, string>{
        {"title", "Register to college"},
        {"deadline", "2022-07-27"}
      };
    HttpContent requestBody = new FormUrlEncodedContent(requestBodyValue);

    string url = "/api/todo";

    return new PostRequestArrangements(
      url, requestBody
    );
  }

  private async Task<string> WhenEndpointIsPostRequested(
    PostRequestArrangements arrangements
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