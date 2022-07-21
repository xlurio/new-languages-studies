namespace HelloWorldAPI.Models;

struct Greeting
{
    public string Message { get; set; }

    public Greeting(string message)
    {
        Message = message;
    }
}