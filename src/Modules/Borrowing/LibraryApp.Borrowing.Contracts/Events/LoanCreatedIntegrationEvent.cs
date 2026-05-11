using LibraryApp.Shared.Contracts.Interfaces;

namespace LibraryApp.Borrowing.Contracts.Events;

public record BookReturnedIntegrationEvent(Guid LoanId, Guid BookId): IIntegrationEvent;