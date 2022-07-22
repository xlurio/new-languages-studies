namespace ToDoAPI.Services;

using ToDoAPI.Adapters;

public interface IUnitOfWork
{
    public IRepository ToDoTaskObjects { get; }

    public void Commit();
}