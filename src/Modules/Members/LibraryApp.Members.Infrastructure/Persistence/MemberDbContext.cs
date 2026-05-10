using LibraryApp.Members.Domain.Entities;
using LibraryApp.Shared.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace LibraryApp.Members.Infrastructure.Persistence;

public class MemberDbContext(DbContextOptions<MemberDbContext> options, IPublisher publisher) : DbContext(options)
{
    public DbSet<Member> Members => Set<Member>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // isolate schemas -> avoid mising tables with other modules
        modelBuilder.HasDefaultSchema("member");
        //------ Auto-discovers all IEntityTypeConfiguration<T> ------//
        // no need for now
        // modelBuilder.ApplyConfigurationsFromAssembly(typeof(MemberDbContext).Assembly);
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