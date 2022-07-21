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
    string response = await WhenGetRequested(url);
    ThenShouldRespondHelloWorld(response);
  }

  private async Task<string> WhenGetRequested(
    string url
  )
  {
    HttpResponseMessage response = await _client.GetAsync(url);
    HttpContent content = response.Content;
    string result = await content.ReadAsStringAsync();

    return result;
  }

  private void ThenShouldRespondHelloWorld(string response)
  {
    string expectedResponse = "Hello, world!";
    StringAssert.Contains(expectedResponse, response);
  }

  [Test]
  public async Task GetHelloFoo()
  {
    string url = GivenTheURL();
    string response = await WhenPostRequested(url);
    ThenShouldRespondHelloFoo(response);
  }

  private string GivenTheURL()
  {
    return "/api/greetings";
  }

  private async Task<string> WhenPostRequested(string url)
  {
    HttpContent toSendContent = new StringContent("name=Foo");
    HttpResponseMessage response = await _client.PostAsync(url, toSendContent);
    HttpContent responseContent = response.Content;
    string result = await responseContent.ReadAsStringAsync();

    return result;
  }

  private void ThenShouldRespondHelloFoo(string response)
  {
    string expectedResponse = "Hello, Foo!";
    StringAssert.Contains(expectedResponse, response);
  }
}