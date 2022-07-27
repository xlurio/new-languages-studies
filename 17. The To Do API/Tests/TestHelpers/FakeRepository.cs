namespace ToDoAPITests.TestHelpers;

using ToDoAPI.Adapters;
using ToDoAPI.Models;
using ToDoAPI.Exceptions;
using System.Collections.Generic;
using Microsoft.AspNetCore.JsonPatch;
using ToDoAPI.Filters;

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

    public IModel Get(int reference)
    {
        IModel? objectFound =
            _data.Find(
                objectData => (objectData as ToDoTask)!.TaskId == reference
            );

        if (objectFound == null)
        {
            throw new TaskNotFoundException(
                $"No task was found with the id {reference}"
            );
        }

        return objectFound!;
    }

    public void Replace(int reference, IModel updatedObject)
    {
        IModel objectFound = Get(reference);
        ToDoTask foundTask = (objectFound as ToDoTask)!;
        ToDoTask updatedTask = (updatedObject as ToDoTask)!;

        foundTask.Title = updatedTask.Title;
        foundTask.Deadline = updatedTask.Deadline;
    }

    public void Update(int reference, JsonPatchDocument newData)
    {
        IModel objectFound = Get(reference);
        ToDoTask foundTask = (objectFound as ToDoTask)!;

        newData.ApplyTo(foundTask);
    }

    public void Remove(int reference)
    {
        IModel objectFound = Get(reference);
        int indexToRemove = _data.IndexOf(objectFound);

        _data.RemoveAt(indexToRemove);
    }

    public List<IModel> Filter(IFilter filter)
    {
        ToDoTaskFilter parsedFilter = (filter as ToDoTaskFilter)!;

        if (parsedFilter.FromDate == null && parsedFilter.ToDate == null)
        {
            return Get();
        }

        List<IModel> objectsFound =
            _data.FindAll(
                objectData => CheckFilterOnTask(parsedFilter, objectData)
            );

        if (objectsFound.Count > 0)
        {
            return objectsFound;
        }

        throw new TaskNotFoundException(
            "No task was found within the parameters"
        );
    }

    private bool CheckFilterOnTask(ToDoTaskFilter filter, IModel objectToFilter)
    {
        DateTime? taskDeadline = GetTaskDeadline(objectToFilter);

        bool isAfterLowerBound =
        IsDateAfter(taskDeadline, filter.FromDate);

        bool isBeforeUpperBound =
        IsDateAfter(filter.ToDate, taskDeadline);

        return isAfterLowerBound && isBeforeUpperBound;
    }

    private DateTime? GetTaskDeadline(IModel taskObject)
    {
        ToDoTask task = (taskObject as ToDoTask)!;

        return task.Deadline;
    }

    private bool IsDateAfter(DateTime? dateToCheck, DateTime? dateBefore)
    {
        int dayVariation = DateTime.Compare(dateBefore!.Value, dateToCheck!.Value);
        return dayVariation <= 0;
    }
}