using LibraryApp.Shared.Contracts.Primitives;

namespace LibraryApp.Borrowing.Contracts.Requests;

public class LoanPagedRequestContract : PagedRequest
{
    public Guid? BookId { get; set; }
    public Guid? MemberId { get; set; }
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
}