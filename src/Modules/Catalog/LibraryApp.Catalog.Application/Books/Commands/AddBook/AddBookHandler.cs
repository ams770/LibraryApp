using LibraryApp.Catalog.Application.Interfaces;
using LibraryApp.Catalog.Domain.Entities;
using LibraryApp.Catalog.Domain.Interfaces;
using LibraryApp.Shared.Contracts.Primitives;
using MediatR;

namespace LibraryApp.Catalog.Application.Books.Commands.AddBook;

public class AddBookHandler(IUnitOfWork unitOfWork, IAuthorRepo authorRepo, IBookRepo bookRepo) : IRequestHandler<AddBookCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(AddBookCommand request, CancellationToken cancellationToken)
    {
        // Check that the author exists
        var author = await authorRepo.GetByIdAsync(request.AuthorId);
        if (author == null) return Result<Guid>.Failure("Author not found");
        // Create & save the new book
        var book = Book.Create(author.Id, request.Title, request.IsAvailable);
        await bookRepo.AddAsync(book);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<Guid>.Success(book.Id);
    }
}