using LibraryApp.Catalog.Application.Common.Exceptions;
using LibraryApp.Catalog.Application.Interfaces;
using LibraryApp.Catalog.Domain.Entities;
using LibraryApp.Catalog.Domain.interfaces;
using LibraryApp.Shared.Domain.Entities;
using MediatR;

namespace LibraryApp.Catalog.Application.Books.Commands.AddBook;

public class AddBookService(IUnitOfWork unitOfWork,IAuthorRepo authorRepo, IBookRepo bookRepo) : IRequestHandler<AddBookCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(AddBookCommand request, CancellationToken cancellationToken)
    {
        // Check that the author exists
        var author = await authorRepo.GetByIdAsync(request.AuthorId) ?? throw new NotFoundException(nameof(Author), request.AuthorId);
        // Create & save the new book
        var book = Book.Create(author.Id, request.Title, request.IsAvailable);
        await bookRepo.AddAsync(book);
        await unitOfWork.SaveChangesAsync();
        
        return Result<Guid>.Success(book.Id);
    }
}