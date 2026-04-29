using LibraryApp.Shared.Domain.Entities;

namespace LibraryApp.Catalog.Domain.Common;

public class BookPagedRequest : PagedRequest
{
    public Guid? AuthorId { get; set; }
}