using LibraryApp.Catalog.Application.Common.Exceptions;
using LibraryApp.Catalog.Application.Interfaces;
using LibraryApp.Catalog.Domain.Entities;
using LibraryApp.Catalog.Domain.interfaces;
using LibraryApp.Shared.Domain.Entities;
using MediatR;

namespace LibraryApp.Catalog.Application.Books.Commands.MarkBookAsUnAvailable;

public class MarkBookAsUnAvailableService(IUnitOfWork unitOfWork, IBookRepo bookRepo) : IRequestHandler<MarkBookAsUnAvailableCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(MarkBookAsUnAvailableCommand request, CancellationToken cancellationToken)
    {
        var book = await bookRepo.GetByIdAsync(request.BookId) ?? throw new NotFoundException(nameof(Book), request.BookId);
        book.MarkAsAvailable();
        await unitOfWork.SaveChangesAsync();
        return Result<Guid>.Success(book.Id);
    }
}