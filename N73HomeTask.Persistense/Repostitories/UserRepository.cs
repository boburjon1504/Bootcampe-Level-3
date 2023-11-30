using System.Linq.Expressions;
using N73HomeTask.Domain.Entities;
using N73HomeTask.Persistense.DataAccess;
using N73HomeTask.Persistense.Repostitories.Interfaces;

namespace N73HomeTask.Persistense.Repostitories;

public class UserRepository(NotificationDbContext context) : 
    EntityRepositoryBase<User,NotificationDbContext>(context),IUserRepository
{
    public IQueryable<User> Get(Expression<Func<User, bool>>? predicate = default, bool asNoTracking = false)
        => base.Get(predicate, asNoTracking);

    public ValueTask<IList<User>> GetByIdsAsync(
        IEnumerable<Guid> usersId,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
    ) =>
        base.GetByIdsAsync(usersId, asNoTracking, cancellationToken);

    public ValueTask<User?> GetByIdAsync(
        Guid userId,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
    ) =>
        base.GetByIdAsync(userId, asNoTracking, cancellationToken);
}