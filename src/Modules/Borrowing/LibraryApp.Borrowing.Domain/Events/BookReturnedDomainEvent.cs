using LibraryApp.Shared.Domain.Interfaces;

namespace LibraryApp.Borrowing.Domain.Events;

public record BookReturnedDomainEvent(Guid LoanId, Guid BookId) : IDomainEvent;