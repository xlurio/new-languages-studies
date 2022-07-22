namespace ToDoAPI.Services;

using System.Data.Entity;

public class UnitOfWork : IUnitOfWork
{
    public UnitOfWork ()
    {
        DbContext context = new ToDoContext();
        ToDoTaskObjects = new ToDoTasks(context);
    }

}