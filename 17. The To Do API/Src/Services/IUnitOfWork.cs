namespace ToDoAPI.Services;

using ToDoAPI.Adapters;

interface IUnitOfWork
{
    public IRepository ToDoTaskObjects { get; }

    public void Commit();
}