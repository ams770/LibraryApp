using LibraryApp.Catalog.Domain.Common;
using LibraryApp.Catalog.Domain.Entities;

namespace LibraryApp.Catalog.Domain.interfaces;

public interface IBookRepo: IDomainRepo<Book>
{
    Task<PagedResult<Book>> GetAllAsync(BookPagedRequest query);
}