namespace ToDoAPITests.TestHelpers;

using ToDoAPI.Adapters;
using ToDoAPI.Models;
using System.Collections.Generic;

public class FakeRepository : IRepository
{
    private List<IModel> _data;
    public FakeRepository()
    {
        _data = new List<IModel>(3);
    }

    public FakeRepository(List<IModel> data)
    {
        _data = data;
    }

    public void Add(IModel objectToAdd)
    {
        _data.Add(objectToAdd);
    }

    public List<IModel> Get()
    {
        return _data;
    }

    public List<IModel> Get(int reference)
    {
        return _data.FindAll(objectData => (objectData as ToDoTask).TaskId == reference);
    }
}