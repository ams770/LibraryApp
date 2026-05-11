using LibraryApp.Shared.Domain.Interfaces;

namespace LibraryApp.Borrowing.Domain.Events;

public record LoanCreatedDomainEvent(Guid LoanId, Guid BookId, Guid MemberId) : IDomainEvent;