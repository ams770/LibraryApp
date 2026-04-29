using LibraryApp.Catalog.Application.Interfaces;

namespace LibraryApp.Catalog.Infrastructure.Persistence.Repositories;

public class UnitOfWork(CatalogDbContext dbContext): IUnitOfWork 
{
    public async Task SaveChangesAsync()
    {
        await dbContext.SaveChangesAsync();
    }
}