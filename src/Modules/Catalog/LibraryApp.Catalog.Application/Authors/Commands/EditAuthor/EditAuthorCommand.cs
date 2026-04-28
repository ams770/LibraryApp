using LibraryApp.Shared.Domain;
using MediatR;

namespace LibraryApp.Catalog.Application.Authors.Commands.AddAuthor;

public record AddAuthorCommand(string FullName) : IRequest<Result<Guid>>;