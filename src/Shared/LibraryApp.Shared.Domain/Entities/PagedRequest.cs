namespace LibraryApp.Catalog.Domain.Common;

public class PagedRequest
{
    private const int MaxPageSize = 50;
    private int _pageSize = 10;
    public int Page { get; set; } = 1;
    public string? SearchTerm { get; set; }

    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value > MaxPageSize ? MaxPageSize : value;
    }
}