using LibraryApp.Borrowing.Domain.Enums;
using LibraryApp.Shared.Contracts.Primitives;

namespace LibraryApp.Borrowing.Domain.Common;

public class LoanPagedRequest : PagedRequest
{
    public Guid? MemberId { get; set; }
    public Guid? BookId { get; set; }
    public string? Status { get; set; }
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
}