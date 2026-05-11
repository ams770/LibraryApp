using LibraryApp.Borrowing.Contracts.Events;
using LibraryApp.Borrowing.Domain.Events;
using MediatR;

namespace LibraryApp.Borrowing.Application.Loans.EventHandlers;

public class AddLoanEventPublisher(IPublisher publisher) : INotificationHandler<LoanCreatedDomainEvent>
{
    public async Task Handle(LoanCreatedDomainEvent notification, CancellationToken ct)
    {
        await publisher.Publish(
            new LoanCreatedIntegrationEvent(notification.LoanId, notification.BookId, notification.MemberId), ct);
    }
}