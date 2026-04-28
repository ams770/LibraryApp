using LibraryApp.Catalog.Domain.Common;

namespace LibraryApp.Catalog.Domain.interfaces;

public interface IDomainRepo<T>
{
    Task AddAsync(T entity);
    Task<T?> GetByIdAsync(Guid id);
}