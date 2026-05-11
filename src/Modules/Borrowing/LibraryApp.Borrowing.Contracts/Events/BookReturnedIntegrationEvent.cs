using LibraryApp.Shared.Contracts.Interfaces;

namespace LibraryApp.Borrowing.Contracts.Requests;

public record BookReturnedIntegrationEvent(Guid LoanId, Guid BookId): IIntegrationEvent;