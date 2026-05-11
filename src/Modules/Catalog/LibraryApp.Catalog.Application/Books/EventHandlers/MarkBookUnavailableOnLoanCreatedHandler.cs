using LibraryApp.Borrowing.Contracts.Events;
using LibraryApp.Catalog.Application.Interfaces;
using LibraryApp.Catalog.Domain.Interfaces; 
using MediatR;

namespace LibraryApp.Catalog.Application.Books.EventHandlers;

public class MarkBookUnavailableOnLoanCreatedHandler(IBookRepo bookRepo, IUnitOfWork unitOfWork) : INotificationHandler<LoanCreatedIntegrationEvent>
{
    public async Task Handle(LoanCreatedIntegrationEvent notification, CancellationToken ct)
    {
        var book = await bookRepo.GetByIdAsync(notification.BookId);
        if(book is null) return;
        
        book.MarkAsUnavailable();
        await unitOfWork.SaveChangesAsync(ct);
    }
}