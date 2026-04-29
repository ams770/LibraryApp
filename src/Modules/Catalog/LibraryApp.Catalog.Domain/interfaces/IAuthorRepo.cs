using LibraryApp.Catalog.Domain.Entities;
using LibraryApp.Shared.Domain.Entities;
using LibraryApp.Shared.Domain.Interfaces;

namespace LibraryApp.Catalog.Domain.interfaces;

public interface IAuthorRepo : IDomainRepo<Author>
{
    Task<PagedResult<Author>> GetAllAsync(PagedRequest query);
}