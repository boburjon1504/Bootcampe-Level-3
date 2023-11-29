using N70HomeTask.Domain.Entities;

namespace N70HomeTask.Application.Service;

public interface IRoleService
{
    IQueryable<Role> Get(Func<Role, bool> predicate, bool asNoTracking = false);
    ValueTask<Role?> GetById(Guid id, bool asNoTracking = false,
        CancellationToken cancellationToken = default);
    ValueTask<Role> CreateAsync(Role role, bool saveChanges = true,
        CancellationToken cancellationToken = default);
    ValueTask<Role> UpdateAsync(Role role, bool saveChanges = true,
        CancellationToken cancellationToken = default);
    ValueTask<Role> DeleteAsync(Role role, bool saveChanges = true,
        CancellationToken cancellationToken = default);

}