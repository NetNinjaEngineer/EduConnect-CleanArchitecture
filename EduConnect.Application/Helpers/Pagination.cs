namespace EduConnect.Application.Helpers;
public class Pagination<T>
{
    public IReadOnlyList<T> Data { get; set; }
    public PaginationMetaData MetaData { get; set; }

    public Pagination(int pageNumber, int pageSize, int count, IReadOnlyList<T> data)
    {
        Data = data;
        MetaData = new()
        {
            CurrentPage = pageNumber,
            PageSize = pageSize,
            TotalCount = count,
            TotalPages = (int)Math.Ceiling(count / (double)pageSize)
        };
    }
}
