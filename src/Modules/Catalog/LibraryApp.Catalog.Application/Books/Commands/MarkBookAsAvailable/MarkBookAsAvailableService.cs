using LibraryApp.Catalog.Application.Common.Exceptions;
using LibraryApp.Catalog.Application.Interfaces;
using LibraryApp.Catalog.Domain.Entities;
using LibraryApp.Catalog.Domain.interfaces;
using LibraryApp.Shared.Domain.Entities;
using MediatR;

namespace LibraryApp.Catalog.Application.Books.Commands.MarkBookAsAvailable;

public class MarkBookAsAvailableService(IUnitOfWork unitOfWork, IBookRepo bookRepo) : IRequestHandler<MarkBookAsAvailableCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(MarkBookAsAvailableCommand request, CancellationToken cancellationToken)
    {
        var book = await bookRepo.GetByIdAsync(request.BookId) ?? throw new NotFoundException(nameof(Book), request.BookId);
        book.MarkAsAvailable();
        await unitOfWork.SaveChangesAsync();
        return Result<Guid>.Success(book.Id);
    }
}