using LibraryApp.Shared.Contracts.Interfaces;

namespace LibraryApp.Borrowing.Contracts.Events;

public record LoanCreatedIntegrationEvent(Guid LoanId, Guid BookId, Guid MemberId): IIntegrationEvent;