namespace ToDoAPI.Services;

using Microsoft.EntityFrameworkCore;
using ToDoAPI.Adapters;

public class UnitOfWork : IUnitOfWork
{
    private ToDoContext _context;
    public IRepository ToDoTaskObjects { get; }

    public UnitOfWork (ToDoContext context)
    {
        _context = context;
        ToDoTaskObjects = new TaskRepository(_context);
    }

    public void Commit(){
        _context.SaveChanges();
    }
}