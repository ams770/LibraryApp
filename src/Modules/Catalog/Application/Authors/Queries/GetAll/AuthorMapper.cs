using LibraryApp.Catalog.Domain.Entities;
using LibraryApp.Shared.Contracts.Dtos;

namespace LibraryApp.Catalog.Application.Authors.Queries.GetAll;

public static class AuthorMapper
{
    public static AuthorDto ToDto(this Author author) => new(author.Id, author.FullName);
}