using N76_HomeTask.Domain.Models;
using N76_HomeTask.Persistense.DataAccess;

namespace N76_HomeTask.Persistense.Repositories;

public class BookRepository(AppDbContext context) : EntityBaseRepository<Book,AppDbContext>(context),
    IBookRepository
{
    public IQueryable<Book> Get(Func<Book, bool> predicate, bool asNoTracking = false)
    {
        return base.Get(predicate, asNoTracking);
    }

    public ValueTask<Book?> GetById(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return base.GetByIdAsync(id, asNoTracking, cancellationToken);
    }

    public ValueTask<Book> CreateAsync(Book user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.CreateAsync(user, saveChanges, cancellationToken);
    }

    public ValueTask<Book> UpdateAsync(Book user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.UpdateAsync(user, saveChanges, cancellationToken);
    }

    public ValueTask<Book> DeleteAsync(Book user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.DeleteAsync(user, saveChanges, cancellationToken);
    }
}