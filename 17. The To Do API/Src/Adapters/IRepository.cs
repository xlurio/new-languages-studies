namespace ToDoAPI.Adapters;

using ToDoAPI.Models;

public interface IRepository
{
    public void Add(IModel objectToAdd);

    public List<IModel> Get();

    public List<IModel> Get(int reference);
}