using LibraryApp.Members.Application.Members.Queries.Mappers;
using LibraryApp.Members.Domain.Interfaces;
using LibraryApp.Shared.Contracts.Dtos;
using LibraryApp.Shared.Contracts.Primitives;
using MediatR;

namespace LibraryApp.Members.Application.Members.Queries.GetAll;

public class GetAllMembersHandler(IMemberRepo memberRepo) : IRequestHandler<GetAllMembersQuery, Result<PagedResult<MemberDto>>>
{
    public async Task<Result<PagedResult<MemberDto>>> Handle(GetAllMembersQuery request, CancellationToken cancellationToken)
    {
        var queryRequest = new PagedRequest
        {
            Page = request.Page,
            PageSize = request.PageSize,
            SearchTerm = request.SearchTerm,
        };

        var result = await memberRepo.GetAllAsync(queryRequest);

        var resultMapped = new PagedResult<MemberDto>
        {
            Page =  result.Page,
            PageSize = result.PageSize,
            TotalCount = result.TotalCount,
            Items = result.Items.Select(item=> item.ToDto()).ToList()
        };
        
        return Result<PagedResult<MemberDto>>.Success(resultMapped);
    }
}