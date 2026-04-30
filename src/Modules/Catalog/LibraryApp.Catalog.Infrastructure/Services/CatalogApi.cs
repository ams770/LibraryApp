using LibraryApp.Catalog.Application.Authors.Commands.AddAuthor;
using LibraryApp.Catalog.Application.Authors.Commands.EditAuthor;
using LibraryApp.Catalog.Application.Authors.Queries.GetAll;
using LibraryApp.Catalog.Application.Books.Commands.AddBook;
using LibraryApp.Catalog.Application.Books.Commands.MarkBookAsAvailable;
using LibraryApp.Catalog.Application.Books.Commands.MarkBookAsUnAvailable;
using LibraryApp.Catalog.Application.Books.Queries.GetAll;
using LibraryApp.Catalog.Application.Books.Queries.GetById;
using LibraryApp.Catalog.Contracts.Requests;
using LibraryApp.Catalog.Contracts.Services;
using LibraryApp.Shared.Contracts.Dtos;
using LibraryApp.Shared.Contracts.Primitives;
using MediatR;

namespace LibraryApp.Catalog.Infrastructure.Services;

public class CatalogApi(ISender sender) : ICatalogApi
{
    public Task<Result<Guid>> AddBookAsync(string title, Guid authorId, bool isAvailable,
        CancellationToken ct = default)
        => sender.Send(new AddBookCommand(authorId, title, isAvailable), ct);


    public Task<Result<BookDto>> GetBookByIdAsync(Guid bookId, CancellationToken ct = default) =>
        sender.Send(new GetBookByIdQuery(bookId), ct);

    public Task<Result<PagedResult<BookDto>>> GetAllBooksAsync(BookPagedRequestContract query,
        CancellationToken ct = default)
        => sender.Send(new GetAllBooksQuery(query.Page, query.PageSize, query.SearchTerm, query.AuthorId), ct);

    public Task<Result> MarkBookAvailableAsync(Guid bookId, CancellationToken ct = default)
        => sender.Send(new MarkBookAsAvailableCommand(bookId), ct);

    public Task<Result> MarkBookUnavailableAsync(Guid bookId, CancellationToken ct = default)
        => sender.Send(new MarkBookAsUnAvailableCommand(bookId), ct);

    public Task<Result<Guid>> AddAuthorAsync(string name, CancellationToken ct = default)
        => sender.Send(new AddAuthorCommand(name), ct);

    public Task<Result> EditAuthorAsync(Guid authorId, string name, CancellationToken ct = default)
        => sender.Send(new EditAuthorCommand(authorId, name), ct);

    public Task<Result<PagedResult<AuthorDto>>> GetAllAuthorsAsync(PagedRequest query, CancellationToken ct = default)
        => sender.Send(new GetAllAuthorsQuery
        {
            Page = query.Page,
            PageSize = query.PageSize,
            SearchTerm = query.SearchTerm,
        }, ct);
}