using LibraryApp.Borrowing.Contracts.Events;
using LibraryApp.Borrowing.Domain.Events;
using MediatR;

namespace LibraryApp.Borrowing.Application.Loans.EventHandlers;

public class BookReturnedEventPublisher(IPublisher publisher) : INotificationHandler<BookReturnedDomainEvent>
{
    public async Task Handle(BookReturnedDomainEvent notification, CancellationToken ct)
    {
        await publisher.Publish(
            new BookReturnedIntegrationEvent(notification.LoanId, notification.BookId), ct);
    }
}