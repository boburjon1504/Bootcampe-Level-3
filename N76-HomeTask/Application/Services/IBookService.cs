using N76_HomeTask.Domain.Models;

namespace N76_HomeTask.Application.Services;

public interface IBookService
{
    IQueryable<Book> Get(Func<Book, bool> predicate, bool asNoTracking = false);
    ValueTask<Book?> GetById(Guid id, bool asNoTracking = false,
        CancellationToken cancellationToken = default);
    ValueTask<Book> CreateAsync(Book book, bool saveChanges = true,
        CancellationToken cancellationToken = default);
    ValueTask<Book> UpdateAsync(Book book, bool saveChanges = true,
        CancellationToken cancellationToken = default);
    ValueTask<Book> DeleteAsync(Book book, bool saveChanges = true,
        CancellationToken cancellationToken = default);

}