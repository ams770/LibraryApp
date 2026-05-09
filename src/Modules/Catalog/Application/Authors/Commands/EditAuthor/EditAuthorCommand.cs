using LibraryApp.Shared.Contracts.Primitives;
using MediatR;

namespace LibraryApp.Catalog.Application.Authors.Commands.EditAuthor;

public record EditAuthorCommand(Guid Id, string FullName) : IRequest<Result>;