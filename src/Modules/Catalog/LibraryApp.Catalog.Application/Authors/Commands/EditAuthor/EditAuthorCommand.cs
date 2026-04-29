using LibraryApp.Shared.Contracts.Primitives;
using MediatR;

namespace LibraryApp.Catalog.Application.Authors.Commands.EditAuthor;

public record EditAuthorCommand(string FullName) : IRequest<Result>;