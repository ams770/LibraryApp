using LibraryApp.Catalog.Application.Interfaces;
using LibraryApp.Shared.Contracts.Primitives;
using LibraryApp.Catalog.Domain.interfaces;
using MediatR;

namespace LibraryApp.Catalog.Application.Books.Commands.MarkBookAsUnAvailable;

public class MarkBookAsUnAvailableHandler(IUnitOfWork unitOfWork, IBookRepo bookRepo) : IRequestHandler<MarkBookAsUnAvailableCommand, Result>
{
    public async Task<Result> Handle(MarkBookAsUnAvailableCommand request, CancellationToken cancellationToken)
    {
        var book = await bookRepo.GetByIdAsync(request.BookId);
        if(book is null) return Result.Failure("Book not found");
        book.MarkAsUnavailable();
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}