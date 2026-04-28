using LibraryApp.Shared.Domain;
using MediatR;

namespace LibraryApp.Catalog.Application.Authors.Commands.EditAuthor;

public record EditAuthorCommand(string FullName) : IRequest<Result<object>>;