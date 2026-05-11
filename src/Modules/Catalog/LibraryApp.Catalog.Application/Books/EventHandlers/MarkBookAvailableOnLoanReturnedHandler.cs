// todo -> remove this ref
using LibraryApp.Borrowing.Domain.Events;
using LibraryApp.Catalog.Application.Interfaces;
using LibraryApp.Catalog.Domain.Interfaces; // Temp => will be removed latter¸
// ---
using MediatR;

namespace LibraryApp.Catalog.Application.Books.EventHandlers;

public class MarkBookAvailableOnLoanReturnedHandler(IBookRepo bookRepo, IUnitOfWork unitOfWork) : INotificationHandler<BookReturnedDomainEvent>
{
 
    public async Task Handle(BookReturnedDomainEvent notification, CancellationToken ct)
    {
        var book = await bookRepo.GetByIdAsync(notification.BookId);
        if(book is null) return;
        
        book.MarkAsAvailable();
        await unitOfWork.SaveChangesAsync(ct);
    }
}