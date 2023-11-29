using N76_HomeTask.Domain.Models;

namespace N76_HomeTask.Application.Services;

public interface IUserService
{
    IQueryable<User> Get(Func<User, bool> predicate, bool asNoTracking = false);
    ValueTask<User?> GetById(Guid id, bool asNoTracking = false,
        CancellationToken cancellationToken = default);
    ValueTask<User> CreateAsync(User user, bool saveChanges = true,
        CancellationToken cancellationToken = default);
    ValueTask<User> UpdateAsync(User user, bool saveChanges = true,
        CancellationToken cancellationToken = default);
    ValueTask<User> DeleteAsync(User user, bool saveChanges = true,
        CancellationToken cancellationToken = default);

}