using LibraryApp.Shared.Contracts.Dtos;
using LibraryApp.Shared.Contracts.Primitives;
using MediatR;

namespace LibraryApp.Members.Application.Members.Queries.GetById;

public record GetMemberByIdQuery(Guid Id) : IRequest<Result<MemberDto>>;