namespace ToDoAPI.Adapters;

using ToDoAPI.Models;
using Microsoft.AspNetCore.JsonPatch;

public interface IRepository
{
    public void Add(IModel objectToAdd);

    public List<IModel> Get();

    public IModel Get(int reference);

    public void Replace(int reference, IModel updatedObject);

    public void Update(int reference, JsonPatchDocument newData);

    public void Remove(int reference);
}