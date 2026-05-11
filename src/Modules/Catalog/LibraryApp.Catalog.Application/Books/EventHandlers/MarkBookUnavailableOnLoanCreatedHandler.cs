// todo -> remove this ref
using LibraryApp.Borrowing.Domain.Events;
using LibraryApp.Catalog.Application.Interfaces;
using LibraryApp.Catalog.Domain.Interfaces; // Temp => will be removed latter¸
// ---
using MediatR;

namespace LibraryApp.Catalog.Application.Books.EventHandlers;

public class MarkBookUnavailableOnLoanCreatedHandler(IBookRepo bookRepo, IUnitOfWork unitOfWork) : INotificationHandler<LoanCreatedDomainEvent>
{
    public async Task Handle(LoanCreatedDomainEvent notification, CancellationToken ct)
    {
        var book = await bookRepo.GetByIdAsync(notification.BookId);
        if(book is null) return;
        
        book.MarkAsUnavailable();
        await unitOfWork.SaveChangesAsync(ct);
    }
}