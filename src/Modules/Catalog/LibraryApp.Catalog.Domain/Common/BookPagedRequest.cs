using LibraryApp.Shared.Contracts.Primitives;
namespace LibraryApp.Catalog.Domain.Common;

public class BookPagedRequest : PagedRequest
{
    public Guid? AuthorId { get; set; }
}