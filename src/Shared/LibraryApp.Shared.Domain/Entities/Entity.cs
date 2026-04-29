using LibraryApp.Shared.Domain.Interfaces;

namespace LibraryApp.Shared.Domain.Entities;

public abstract class Entity<TId>
{
    public TId Id { get; protected set; } = default!;
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    
    private readonly List<IDomainEvent> _domainEvents = [];
    // for the infrastructure layer to collect events
    public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();
    // protected ->> never raised from outside the business layer
    protected void RaiseDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
    // should be called after dispatching
    public void ClearDomainEvents() => _domainEvents.Clear();
}