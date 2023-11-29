using N70HomeTask.Domain.Entities;

namespace N70HomeTask.Persistense.Repositories.RoleRepositories;

public interface IRoleRepository
{
    IQueryable<Role> Get(Func<Role, bool> predicate, bool asNoTracking = false);
    ValueTask<Role?> GetById(Guid id, bool asNoTracking = false,
        CancellationToken cancellationToken = default);
    ValueTask<Role> CreateAsync(Role user, bool saveChanges = true,
        CancellationToken cancellationToken = default);
    ValueTask<Role> UpdateAsync(Role user, bool saveChanges = true,
        CancellationToken cancellationToken = default);
    ValueTask<Role> DeleteAsync(Role user, bool saveChanges = true,
        CancellationToken cancellationToken = default);

}