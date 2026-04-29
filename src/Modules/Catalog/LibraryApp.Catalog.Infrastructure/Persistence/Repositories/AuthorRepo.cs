using LibraryApp.Catalog.Domain.Entities;
using LibraryApp.Catalog.Domain.interfaces;
using LibraryApp.Shared.Contracts.Primitives;
using Microsoft.EntityFrameworkCore;


namespace LibraryApp.Catalog.Infrastructure.Persistence.Repositories;

public class AuthorRepo(CatalogDbContext dbContext) : IAuthorRepo
{
    public async Task AddAsync(Author entity)
    {
        await dbContext.AddAsync(entity);
    }

    public async Task<Author?> GetByIdAsync(Guid id)
    {
        return await dbContext.Authors
            .FindAsync(id);
    }

    public async Task<PagedResult<Author>> GetAllAsync(PagedRequest query)
    {
        var q = dbContext.Authors
            .AsQueryable();
        // Apply Needed Queries
        if (query.SearchTerm is not null)
            q = q.Where(b => b.FullName.ToLower().Contains(query.SearchTerm.ToLower()));

        // Apply Pagination
        var totalCount = await q.CountAsync();
        var items = await q
            .Skip((query.Page - 1) * query.PageSize)
            .Take(query.PageSize)
            .ToListAsync();

        return new PagedResult<Author>
        {
            Items = items,
            TotalCount = totalCount,
            Page = query.Page,
            PageSize = query.PageSize
        };
    }
}