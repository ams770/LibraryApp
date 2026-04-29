using LibraryApp.Shared.Domain.Interfaces;

namespace LibraryApp.Catalog.Domain.Events;

public record BookCreatedDomainEvent(Guid BookId) : IDomainEvent;