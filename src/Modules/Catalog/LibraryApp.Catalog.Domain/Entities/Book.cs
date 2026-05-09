using LibraryApp.Catalog.Domain.Events;
using LibraryApp.Shared.Domain.Entities;
using LibraryApp.Shared.Domain.Exceptions;

namespace LibraryApp.Catalog.Domain.Entities;

public class Book : Entity<Guid>
{
    public string Title { get; private set; } = string.Empty;
    public Guid AuthorId { get; private set; }
    public Author Author { get; private set; }
    public bool IsAvailable { get; private set; }

    private Book()
    {
    }

    public static Book Create(Guid authorId, string title, bool isAvailable)
    {
        ValidateTitle(title);
        var book = new Book
        {
            Id = Guid.NewGuid(),
            AuthorId = authorId,
            Title = title,
            IsAvailable = isAvailable
        };
        
        book.RaiseDomainEvent(new BookCreatedDomainEvent(book.Id));
        
        return book;
    }

    public void SetTitle(string title)
    {
        ValidateTitle(title);
        Title = title;
    }
    
    
    public void MarkAsAvailable() => IsAvailable = true;
    public void MarkAsUnavailable() => IsAvailable = false;
    

    private static void ValidateTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title)) throw new DomainException("Title is required");
    }
}