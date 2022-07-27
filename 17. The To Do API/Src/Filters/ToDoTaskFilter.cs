namespace ToDoAPI.Filters;

public class ToDoTaskFilter : IFilter
{
  public DateTime? FromDate { get; set; }
  public DateTime? ToDate { get; set; }

  public ToDoTaskFilter(string unformattedFromDate, string unformattedToDate)
  {
    string datePattern = "yyyy-MM-dd";

    FromDate = DateTime.ParseExact(
      unformattedFromDate, datePattern, null
    );
    ToDate = DateTime.ParseExact(
      unformattedToDate, datePattern, null
    );
  }

  public ToDoTaskFilter()
  {
  }
}