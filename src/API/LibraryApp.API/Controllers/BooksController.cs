using LibraryApp.Catalog.Contracts.Requests;
using LibraryApp.Catalog.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController(ICatalogApi catalog) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddBook(
        AddBookRequestContract request, CancellationToken ct)
    {
        var result = await catalog.AddBookAsync(request.Title, request.AuthorId, request.IsAvailable, ct);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetBook(Guid id, CancellationToken ct)
    {
        var result = await catalog.GetBookByIdAsync(id, ct);
        return result.IsSuccess ? Ok(result) : NotFound(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBooks(
        [FromQuery] BookPagedRequestContract query, CancellationToken ct)
    {
        var result = await catalog.GetAllBooksAsync(query, ct);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpPatch("{id:guid}/available")]
    public async Task<IActionResult> MarkAvailable(Guid id, CancellationToken ct)
    {
        var result = await catalog.MarkBookAvailableAsync(id, ct);
        return result.IsSuccess ? Ok() : BadRequest(result);
    }

    [HttpPatch("{id:guid}/unavailable")]
    public async Task<IActionResult> MarkUnavailable(Guid id, CancellationToken ct)
    {
        var result = await catalog.MarkBookUnavailableAsync(id, ct);
        return result.IsSuccess ? Ok() : BadRequest(result);
    }
}