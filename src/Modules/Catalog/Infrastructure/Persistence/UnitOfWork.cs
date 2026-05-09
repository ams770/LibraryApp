using LibraryApp.Catalog.Application.Interfaces;

namespace LibraryApp.Catalog.Infrastructure.Persistence;

public class UnitOfWork(CatalogDbContext dbContext) : IUnitOfWork
{
    public async Task SaveChangesAsync(CancellationToken ct = default)
    {
        await dbContext.SaveChangesAsync(ct);
    }
}