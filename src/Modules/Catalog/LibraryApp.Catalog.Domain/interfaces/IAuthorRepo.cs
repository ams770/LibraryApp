using LibraryApp.Catalog.Domain.Common;
using LibraryApp.Catalog.Domain.Entities;

namespace LibraryApp.Catalog.Domain.interfaces;

public interface IAuthorRepo : IDomainRepo<Author>
{
    Task<PagedResult<Author>> GetAllAsync(PagedRequest query);
}