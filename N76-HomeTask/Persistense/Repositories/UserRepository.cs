using N76_HomeTask.Domain.Models;
using N76_HomeTask.Persistense.DataAccess;

namespace N76_HomeTask.Persistense.Repositories;

public class UserRepository(AppDbContext context) : EntityBaseRepository<User,AppDbContext>(context),
    IUserRepository 
{
    public IQueryable<User> Get(Func<User, bool> predicate, bool asNoTracking = false)
    {
        return base.Get(predicate, asNoTracking);
    }

    public ValueTask<User?> GetById(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return base.GetByIdAsync(id, asNoTracking, cancellationToken);
    }

    public ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.CreateAsync(user, saveChanges, cancellationToken);
    }

    public ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.UpdateAsync(user, saveChanges, cancellationToken);
    }

    public ValueTask<User> DeleteAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.DeleteAsync(user, saveChanges, cancellationToken);
    }
}