using LibraryApp.Catalog.Domain.Entities;
using LibraryApp.Shared.Contracts.Primitives;
using LibraryApp.Shared.Domain.Interfaces;


namespace LibraryApp.Catalog.Domain.Interfaces;

public interface IAuthorRepo : IDomainRepo<Author>
{
    Task<PagedResult<Author>> GetAllAsync(PagedRequest query);
}