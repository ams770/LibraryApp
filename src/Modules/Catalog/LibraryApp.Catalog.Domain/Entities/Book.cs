using LibraryApp.Catalog.Domain.Events;
using LibraryApp.Catalog.Domain.Exceptions;
using LibraryApp.Shared.Domain;

namespace LibraryApp.Catalog.Domain.Entities;

public class Book : Entity<Guid>
{
    public string Title { get; private set; } = string.Empty;
    public string Author { get; private set; } = string.Empty;
    public bool IsAvailable { get; private set; }

    private Book()
    {
    }

    public static Book Create(string title, string author, bool isAvailable)
    {
        ValidateInitialData(title, author);
        var book = new Book
        {
            Id = Guid.NewGuid(),
            Title = title,
            Author = author,
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

    public void SetAuthor(string author)
    {
        ValidateAuthor(author);
        Author = author;
    }
    
    public void MarkAsAvailable() => IsAvailable = true;
    public void MarkAsUnavailable() => IsAvailable = false;
    
    
    private static void ValidateInitialData(string title, string author)
    {
        ValidateTitle(title);
        ValidateAuthor(author);
    }

    private static void ValidateTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title)) throw new DomainException("Title is required");
    }

    private static void ValidateAuthor(string author)
    {
        if (string.IsNullOrWhiteSpace(author)) throw new DomainException("Author is required");
    }
}