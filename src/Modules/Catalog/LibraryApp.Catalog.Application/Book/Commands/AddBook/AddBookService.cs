using LibraryApp.Shared.Domain;
using MediatR;

namespace LibraryApp.Catalog.Application.Book.Commands.AddBook;

public class AddBookService : IRequestHandler<AddBookCommand, Result<Guid>>
{
    public Task<Result<Guid>> Handle(AddBookCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}