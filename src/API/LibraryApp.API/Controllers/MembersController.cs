using LibraryApp.Members.Contracts.Requests;
using LibraryApp.Members.Contracts.Services;
using LibraryApp.Shared.Contracts.Primitives;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MembersController(IMemberApi membersApi) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddMember(
        AddMemberRequestContract request, CancellationToken ct)
    {
        var result = await membersApi.AddMemberAsync(request, ct);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpPut]
    public async Task<IActionResult> EditMember(EditMemberRequestContract request, CancellationToken ct)
    {
        var result = await membersApi.EditMemberAsync(request, ct);
        return result.IsSuccess ? Ok() : BadRequest(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetMemberById(
        Guid id, CancellationToken ct)
    {
        var result = await membersApi.GetMemberByIdAsync(id, ct);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpGet("email/{email}")]
    public async Task<IActionResult> GetMemberByEmail(
        string email, CancellationToken ct)
    {
        var result = await membersApi.GetMemberByEmailAsync(email, ct);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllMembers(
        [FromQuery] PagedRequest query, CancellationToken ct)
    {
        var result = await membersApi.GetAllMembersAsync(query, ct);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
}