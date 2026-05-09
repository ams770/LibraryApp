using LibraryApp.Catalog.Domain.Common;
using LibraryApp.Catalog.Domain.Entities;
using LibraryApp.Shared.Contracts.Primitives;
using LibraryApp.Shared.Domain.Interfaces;

namespace LibraryApp.Catalog.Domain.Interfaces;

public interface IBookRepo: IDomainRepo<Book>
{
    Task<PagedResult<Book>> GetAllAsync(BookPagedRequest query);
}