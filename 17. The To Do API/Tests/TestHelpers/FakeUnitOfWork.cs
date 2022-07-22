namespace ToDoAPITests.TestHelpers;

using ToDoAPI.Services;
using ToDoAPI.Models;
using ToDoAPI.Adapters;

public class FakeUnitOfWork : IUnitOfWork
{
    private bool _saved;
    public IRepository ToDoTaskObjects { get; }
    public bool Saved { 
        get
        {
            bool currentState = _saved;
            _saved = false;

            return currentState;
        }
    }

    public FakeUnitOfWork(List<IModel> context)
    {
        ToDoTaskObjects = new FakeRepository(context);
    }

    public void Commit()
    {
        _saved = true;
    }
}