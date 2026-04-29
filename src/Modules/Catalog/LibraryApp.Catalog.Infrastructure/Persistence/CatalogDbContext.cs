using LibraryApp.Catalog.Domain.Entities;
using LibraryApp.Shared.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Catalog.Infrastructure.Persistence;

public class CatalogDbContext(DbContextOptions<CatalogDbContext> options, IPublisher publisher) : DbContext(options)
{
    public DbSet<Book> Books => Set<Book>();
    public DbSet<Author> Authors => Set<Author>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // isolate schemas -> avoid mising tables with other modules
        modelBuilder.HasDefaultSchema("catalog");
        //------ Auto-discovers all IEntityTypeConfiguration<T> ------//
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogDbContext).Assembly);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken ct = default)
    {
        var result = await base.SaveChangesAsync(ct);

        var events = ChangeTracker
            .Entries<Entity<Guid>>()
            .SelectMany(e => e.Entity.DomainEvents)
            .ToList();

        ChangeTracker
            .Entries<Entity<Guid>>()
            .ToList()
            .ForEach(e => e.Entity.ClearDomainEvents());

        foreach (var domainEvent in events)
            await publisher.Publish(domainEvent, ct);

        return result;
    }
}