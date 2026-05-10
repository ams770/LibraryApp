using LibraryApp.Members.Application.Interfaces;

namespace LibraryApp.Members.Infrastructure.Persistence;

public class UnitOfWork(MemberDbContext dbContext) : IUnitOfWork
{
    public async Task SaveChangesAsync(CancellationToken ct = default)
    {
        await dbContext.SaveChangesAsync(ct);
    }
}