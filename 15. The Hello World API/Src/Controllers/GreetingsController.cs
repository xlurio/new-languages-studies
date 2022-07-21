namespace HelloWorldAPI.Controllers;

using HelloWorldAPI.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class GreetingsController : ControllerBase
{
    [HttpGet(Name="GreetWorld")]
    public ActionResult GreetWorld()
    {
        string message = "Hello, world!";
        Greeting greeting = new Greeting(message);

        return Ok(greeting);
    }

    [HttpPost(Name="GreetUser")]
    public ActionResult GreetUser()
    {
        string userName = Request.Form["name"];
        string message = $"Hello, {userName}!";
        Greeting greeting = new Greeting(message);

        return Ok(greeting);
    }
}