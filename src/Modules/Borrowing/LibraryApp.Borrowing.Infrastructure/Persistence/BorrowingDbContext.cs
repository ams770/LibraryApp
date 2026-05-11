using LibraryApp.Borrowing.Domain.Entities;
using LibraryApp.Shared.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace LibraryApp.Borrowing.Infrastructure.Persistence;

public class BorrowingDbContext(DbContextOptions<BorrowingDbContext> options, IPublisher publisher) : DbContext(options)
{
    public DbSet<Loan> Loans => Set<Loan>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // isolate schemas -> avoid mising tables with other modules
        modelBuilder.HasDefaultSchema("borrowing");
        //------ Auto-discovers all IEntityTypeConfiguration<T> ------//
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BorrowingDbContext).Assembly);
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