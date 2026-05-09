using LibraryApp.Shared.Contracts.Primitives;
using MediatR;

namespace LibraryApp.Catalog.Application.Authors.Commands.AddAuthor;

public record AddAuthorCommand(string FullName) : IRequest<Result<Guid>>;