namespace LibraryApp.Catalog.Contracts.Requests;

public record AddBookRequestContract(Guid AuthorId, string Title, bool IsAvailable);