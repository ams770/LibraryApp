using LibraryApp.Shared.Domain.Entities;
using LibraryApp.Shared.Domain.Exceptions;

namespace LibraryApp.Catalog.Domain.Entities;

public class Author : Entity<Guid>
{
    public string FullName { get; private set; } = string.Empty;
    private readonly List<Book> _books = [];
    public IReadOnlyCollection<Book> Books => _books.AsReadOnly();

    private Author()
    {
    }

    public static Author Create(string fullName)
    {
        ValidateName(fullName);
        
        var author = new Author
        {
            Id = Guid.NewGuid(),
            FullName = fullName,
        };

        return author;
    }

    public void SetName(string fullName)
    {
        ValidateName(fullName);
        FullName = fullName;
    }
    
    private static void ValidateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new DomainException("Full name is required");
    }
}