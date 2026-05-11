using LibraryApp.Borrowing.Contracts.Requests;
using LibraryApp.Borrowing.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BorrowingController(IBorrowingApi borrowing) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddLoan(
        AddLoanRequestContract request, CancellationToken ct)
    {
        var result = await borrowing.AddLoanAsync(request, ct);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }


    [HttpGet]
    public async Task<IActionResult> GetAllLoans(
        [FromQuery] LoanPagedRequestContract query, CancellationToken ct)
    {
        var result = await borrowing.GetAllLoansAsync(query, ct);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpPatch("{id:guid}/return")]
    public async Task<IActionResult> ReturnLoan(Guid id, CancellationToken ct)
    {
        var result = await borrowing.ReturnLoanAsync(id, ct);
        return result.IsSuccess ? Ok() : BadRequest(result);
    }

}