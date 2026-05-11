using LibraryApp.Borrowing.Contracts.Events;
using LibraryApp.Catalog.Application.Interfaces;
using LibraryApp.Catalog.Domain.Interfaces;
using MediatR;

namespace LibraryApp.Catalog.Application.Books.EventHandlers;

public class MarkBookAvailableOnLoanReturnedHandler(IBookRepo bookRepo, IUnitOfWork unitOfWork) : INotificationHandler<BookReturnedIntegrationEvent>
{
 
    public async Task Handle(BookReturnedIntegrationEvent notification, CancellationToken ct)
    {
        var book = await bookRepo.GetByIdAsync(notification.BookId);
        if(book is null) return;
        
        book.MarkAsAvailable();
        await unitOfWork.SaveChangesAsync(ct);
    }
}