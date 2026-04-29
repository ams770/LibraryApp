

namespace LibraryApp.Shared.Domain;

public interface IDomainRepo<T>
{
    Task AddAsync(T entity);
    Task<T?> GetByIdAsync(Guid id);
}