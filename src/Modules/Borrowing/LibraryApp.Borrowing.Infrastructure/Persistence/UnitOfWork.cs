using LibraryApp.Borrowing.Application.Interfaces;

namespace LibraryApp.Borrowing.Infrastructure.Persistence;

public class UnitOfWork(BorrowingDbContext dbContext) : IUnitOfWork
{
    public async Task SaveChangesAsync(CancellationToken ct = default)
    {
        await dbContext.SaveChangesAsync(ct);
    }
}