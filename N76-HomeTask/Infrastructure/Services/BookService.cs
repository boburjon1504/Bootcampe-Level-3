using N76_HomeTask.Application.Services;
using N76_HomeTask.Domain.Models;
using N76_HomeTask.Persistense.Repositories;

namespace N76_HomeTask.Infrastructure.Services;

public class BookService(IBookRepository bookRepository) : IBookService
{
    public IQueryable<Book> Get(Func<Book, bool> predicate, bool asNoTracking = false)
    {
        return bookRepository.Get(predicate, asNoTracking);
    }

    public ValueTask<Book?> GetById(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return bookRepository.GetById(id, asNoTracking, cancellationToken);
    }

    public ValueTask<Book> CreateAsync(Book book, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return bookRepository.CreateAsync(book, saveChanges, cancellationToken);
    }

    public ValueTask<Book> UpdateAsync(Book book, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return bookRepository.UpdateAsync(book, saveChanges, cancellationToken);
    }

    public ValueTask<Book> DeleteAsync(Book book, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return bookRepository.DeleteAsync(book, saveChanges, cancellationToken);
    }
}