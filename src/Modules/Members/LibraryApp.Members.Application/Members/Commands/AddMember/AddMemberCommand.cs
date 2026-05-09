using LibraryApp.Shared.Contracts.Primitives;
using MediatR;

namespace LibraryApp.Members.Application.Members.Commands.AddMember;

public record AddMemberCommand(string FullName, string Email) : IRequest<Result<Guid>>;