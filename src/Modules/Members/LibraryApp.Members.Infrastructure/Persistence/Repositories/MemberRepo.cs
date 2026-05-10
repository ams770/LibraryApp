using LibraryApp.Members.Domain.Entities;
using LibraryApp.Members.Domain.Interfaces;
using LibraryApp.Shared.Contracts.Primitives;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Members.Infrastructure.Persistence.Repositories;

public class MemberRepo(MemberDbContext dbContext) : IMemberRepo
{
    public async Task AddAsync(Member entity)
        => await dbContext.Members.AddAsync(entity);

    public async Task<Member?> GetByIdAsync(Guid id)
        => await dbContext.Members.FindAsync(id);

    public async Task<Member?> GetByEmailAsync(string email)
        => await dbContext.Members.FirstOrDefaultAsync(m => m.Email.ToLower() == email.ToLower());

    public async Task<PagedResult<Member>> GetAllAsync(PagedRequest request)
    {
        var query = dbContext.Members.AsQueryable();

        if (request.SearchTerm is not null)
        {
            query = query.Where(m => m.FullName.ToLower().Contains(request.SearchTerm.ToLower()));
        }

        // Apply Pagination
        var totalCount = await query.CountAsync();
        var items = await query
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync();


        return new PagedResult<Member>
        {
            Items = items,
            TotalCount = totalCount,
            Page = request.Page,
            PageSize = request.PageSize
        };
    }
}