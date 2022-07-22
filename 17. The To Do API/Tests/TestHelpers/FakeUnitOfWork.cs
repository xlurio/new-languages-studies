namespace ToDoAPITests.TestHelpers;

using ToDoAPI.Services;
using ToDoAPI.Models;

public class FakeUnitOfWork : IUnitOfWork
{
    private bool _saved;
    public bool Saved { 
        get
        {
            bool currentState = _saved;
            _saved = false;

            return currentState;
        }
    }

    public FakeUnitOfWork(List<ToDoTask> context)
    {
        ToDoTaskObjects = new FakeRepository(context);
    }

    public void Commit()
    {
        _saved = true;
    }
}