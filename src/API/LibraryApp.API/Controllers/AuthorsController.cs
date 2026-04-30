using LibraryApp.Catalog.Contracts.Requests;
using LibraryApp.Catalog.Contracts.Services;
using LibraryApp.Shared.Contracts.Primitives;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorsController(ICatalogApi catalog) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddAuthor(
        AddAuthorRequestContract request, CancellationToken ct)
    {
        var result = await catalog.AddAuthorAsync(request.Name, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> EditAuthor(
        Guid id, EditAuthorRequestContract request, CancellationToken ct)
    {
        var result = await catalog.EditAuthorAsync(id, request.Name, ct);
        return result.IsSuccess ? Ok() : BadRequest(result.Error);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAuthors(
        [FromQuery] PagedRequest query, CancellationToken ct)
    {
        var result = await catalog.GetAllAuthorsAsync(query, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }
}