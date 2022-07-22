namespace ToDoAPI.Exceptions;

using System;

public class TaskNotFoundException : Exception
{
    public TaskNotFoundException() { }
    public TaskNotFoundException(string message) : base(message) { }
    public TaskNotFoundException(string message, System.Exception inner) : base(message, inner) { }
}