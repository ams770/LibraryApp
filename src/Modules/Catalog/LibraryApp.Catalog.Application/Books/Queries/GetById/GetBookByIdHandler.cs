using LibraryApp.Catalog.Application.Books.Queries.Mappers;
using LibraryApp.Catalog.Domain.Interfaces;
using LibraryApp.Shared.Contracts.Dtos;
using LibraryApp.Shared.Contracts.Primitives;
using MediatR;

namespace LibraryApp.Catalog.Application.Books.Queries.GetById;

public class GetBookByIdHandler(IBookRepo bookRepo) : IRequestHandler<GetBookByIdQuery, Result<BookDto>>
{
    public async Task<Result<BookDto>> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        var book = await bookRepo.GetByIdAsync(request.BookId);
        return book is null ? Result<BookDto>.Failure("B") : Result<BookDto>.Success(book.ToDto());
    }
}