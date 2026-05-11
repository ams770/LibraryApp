using LibraryApp.Borrowing.Domain.Common;
using LibraryApp.Borrowing.Domain.Entities;
using LibraryApp.Borrowing.Domain.Interfaces;
using LibraryApp.Shared.Contracts.Primitives;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Borrowing.Infrastructure.Persistence.Repositories;

public class BorrowingRepo(BorrowingDbContext dbContext) : IBorrowingRepo
{
    public async Task AddAsync(Loan entity)
    {
        await dbContext.AddAsync(entity);
    }

    public async Task<Loan?> GetByIdAsync(Guid id)
        => await dbContext.Loans.FindAsync(id);

    public async Task<PagedResult<Loan>> GetAllAsync(LoanPagedRequest query)
    {
        var q = dbContext.Loans.AsQueryable();
        if (query.MemberId.HasValue) q = q.Where(item => item.MemberId == query.MemberId.Value);
        if (query.BookId.HasValue) q = q.Where(item => item.BookId == query.BookId.Value);
        if (query.Status is not null) q = q.Where(item => item.Status.ToString() == query.Status);

        // Apply Pagination
        var totalCount = await q.CountAsync();
        var items = await q
            .Skip((query.Page - 1) * query.PageSize)
            .Take(query.PageSize)
            .ToListAsync();

        return new PagedResult<Loan>
        {
            Items = items,
            TotalCount = totalCount,
            Page = query.Page,
            PageSize = query.PageSize
        };
    }
}