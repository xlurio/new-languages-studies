namespace ToDoAPI.Services;

using Microsoft.EntityFrameworkCore;
using ToDoAPI.Adapters;

public class UnitOfWork : IUnitOfWork
{
    private DbContext _context;
    public IRepository ToDoTaskObjects { get; }

    public UnitOfWork ()
    {
        _context = new ToDoContext();
        ToDoTaskObjects = new TaskRepository(_context);
    }

    public void Commit(){
        _context.SaveChanges();
    }
}