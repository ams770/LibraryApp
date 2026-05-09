using LibraryApp.Shared.Contracts.Primitives;
namespace LibraryApp.Catalog.Contracts.Requests;

public class BookPagedRequestContract : PagedRequest
{
    public Guid? AuthorId { get; set; }
}