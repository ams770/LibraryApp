using LibraryApp.Catalog.Domain.Common;
using LibraryApp.Catalog.Domain.Entities;
using LibraryApp.Catalog.Domain.interfaces;
using LibraryApp.Shared.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace LibraryApp.Catalog.Infrastructure.Persistence.Repositories;

public class BookRepo(CatalogDbContext dbContext) : IBookRepo
{
    public async Task AddAsync(Book entity)
    {
        await dbContext.AddAsync(entity);
    }

    public async Task<Book?> GetByIdAsync(Guid id)
    {
        return await dbContext.Books
            .Include(i => i.Author)
            .FirstOrDefaultAsync(item => item.Id == id);
    }

    public async Task<PagedResult<Book>> GetAllAsync(BookPagedRequest query)
    {
        var q = dbContext.Books
            .Include(b => b.Author)
            .AsQueryable();
        // Apply Needed Queries
        if (query.AuthorId.HasValue) q = q.Where(b => b.AuthorId == query.AuthorId);
        if (query.SearchTerm is not null)
            q = q.Where(b => b.Title.ToLower().Contains(query.SearchTerm.ToLower()));
        // Apply Pagination
        var totalCount = await q.CountAsync();
        var items = await q
            .Skip((query.Page - 1) * query.PageSize)
            .Take(query.PageSize)
            .ToListAsync();

        return new PagedResult<Book>
        {
            Items = items,
            TotalCount = totalCount,
            Page = query.Page,
            PageSize = query.PageSize
        };
    }
}