using LibraryApp.Catalog.Domain.Common;
using LibraryApp.Catalog.Domain.Entities;
using LibraryApp.Catalog.Domain.interfaces;

namespace LibraryApp.Catalog.Infrastructure.Repositories;

public class BookRepo() : IBookRepo
{
    public Task AddAsync(Book entity)
    {
        throw new NotImplementedException();
    }

    public Task<Book?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<PagedResult<Book>> GetAllAsync(BookPagedRequest query)
    {
        throw new NotImplementedException();
    }
}