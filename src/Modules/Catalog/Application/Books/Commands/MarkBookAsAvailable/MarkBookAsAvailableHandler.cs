using LibraryApp.Catalog.Application.Interfaces;
using LibraryApp.Shared.Contracts.Primitives;
using LibraryApp.Catalog.Domain.interfaces;
using MediatR;

namespace LibraryApp.Catalog.Application.Books.Commands.MarkBookAsAvailable;

public class MarkBookAsAvailableHandler(IUnitOfWork unitOfWork, IBookRepo bookRepo) : IRequestHandler<MarkBookAsAvailableCommand, Result>
{
    public async Task<Result> Handle(MarkBookAsAvailableCommand request, CancellationToken cancellationToken)
    {

        var book = await bookRepo.GetByIdAsync(request.BookId);
        if(book is null) return Result.Failure("Book not found");
        book.MarkAsAvailable();
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}