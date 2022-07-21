using HelloWorldAPI;
using HelloWorldAPI.Controllers;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;

[TestFixture]
class GreetingsControllerTests
{
  private HttpClient _client;

  [SetUp]
  public void SetUp() {
    WebApplicationFactory<Program> factory =
      new WebApplicationFactory<Program>();
    _client = factory.CreateClient();
  }

  [Test]
  public async Task GetHelloWorld()
  {
    string url = GivenTheURL();
    string response = await WhenGETRequested(url);
    ThenShouldRespondHelloWorld(response);
  }

  private string GivenTheURL()
  {
    return "/greetings";
  }

  private async Task<string> WhenGETRequested(
    string url
  )
  {
    HttpResponseMessage response = await _client.GetAsync(url);
    HttpContent content = response.Content;

    return response.ToString();
  }

  private void ThenShouldRespondHelloWorld(string response)
  {
    string expectedResponse = "Hello World!";
    StringAssert.Contains(response, expectedResponse);
  }
}