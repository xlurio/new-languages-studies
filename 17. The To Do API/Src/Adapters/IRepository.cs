namespace ToDoAPI.Adapters;

interface IRepository
{
    public void Add(IEntity objectToAdd);

    public List<IEntity> Get();

    public List<IEntify> Get(int reference);
}