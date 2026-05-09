using LibraryApp.Catalog.Domain.Entities;
using LibraryApp.Shared.Contracts.Dtos;

namespace LibraryApp.Catalog.Application.Books.Queries.Mappers;

public static class BookMapper
{
    public static BookDto ToDto(this Book book) => new(
        book.Id,
        book.Title,
        book.IsAvailable,
        new AuthorDto(book.AuthorId, book.Author.FullName)
    );
}