namespace EduConnect.Application.Helpers;
public class TopicRequestParams
{
    private const int _maxPageSize = 50;
    public int PageNumber { get; set; } = 1;
    private int _pageSize = 10;

    public int PageSize
    {
        get { return _pageSize; }
        set { _pageSize = (value > _maxPageSize) ? _pageSize : value; }
    }

    private string? searchTerm;

    public string? SearchTerm
    {
        get { return searchTerm; }
        set { searchTerm = value!.ToLower(); }
    }
}
