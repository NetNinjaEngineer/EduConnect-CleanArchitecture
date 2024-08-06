namespace EduConnect.Application.Helpers;
public class Pagination<T>
{
    public IReadOnlyList<T> Date { get; set; }
    public PaginationMetaData MetaData { get; set; }

    public Pagination(int pageNumber, int pageSize, int count, IReadOnlyList<T> date)
    {
        Date = date;
        MetaData = new()
        {
            CurrentPage = pageNumber,
            PageSize = pageSize,
            TotalCount = count,
            TotalPages = (int)Math.Ceiling(count / (double)pageSize)
        };
    }
}
