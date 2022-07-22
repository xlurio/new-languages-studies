namespace ToDoAPITests.TestHelpers;

using ToDoAPI.Adapters;
using ToDoAPI.Models;
using System.Collections.Generic;

public class FakeRepository : IRepository
{
    private List<ToDoTask> _data;
    public FakeRepository()
    {
        _data = new List<ToDoTask>(3);
    }

    public FakeRepository(List<ToDoTask> data)
    {
        _data = data;
    }

    public void Add(IEntity objectToAdd)
    {
        _data.Add(objectToAdd);
    }

    public List<IEntity> Get()
    {
        return _data;
    }

    public List<IEntify> Get(int reference)
    {
        return _data.FindAll(objectData => objectData.TaskId == reference);
    }
}