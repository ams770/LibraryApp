using LibraryApp.Shared.Domain;

namespace LibraryApp.Catalog.Domain.Events;

public record BookCreatedDomainEvent(Guid BookId) : IDomainEvent;