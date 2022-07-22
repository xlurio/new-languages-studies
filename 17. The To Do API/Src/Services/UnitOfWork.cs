namespace ToDoAPI.Services;

using System.Data.Entity;
using ToDoAPI.Adapters;

public class UnitOfWork : IUnitOfWork
{
    private DbContext _context;
    public IRepository ToDoTaskObjects { get; }
    
    public UnitOfWork ()
    {
        _context = new ToDoContext();
    }

    public void Commit(){
        _context.SaveChanges();
    }
}