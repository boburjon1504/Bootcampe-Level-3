using N70HomeTask.Domain.Entities;
using N70HomeTask.Persistense.DataAccess;

namespace N70HomeTask.Persistense.Repositories.RoleRepositories;

public class RoleRepository(Identity context) : EntityRepositoryBase<Role,Identity>(context),IRoleRepository
{
    public IQueryable<Role> Get(Func<Role, bool> predicate, bool asNoTracking = false)
    {
        return base.Get(role => true, asNoTracking);
    }

    public ValueTask<Role?> GetById(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return base.GetByIdAsync(id, asNoTracking, cancellationToken);
    }

    public ValueTask<Role> CreateAsync(Role role, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.CreateAsync(role, saveChanges, cancellationToken);
    }

    public ValueTask<Role> UpdateAsync(Role role, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.UpdateAsync(role, saveChanges, cancellationToken);
    }

    public ValueTask<Role> DeleteAsync(Role role, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.DeleteAsync(role, saveChanges, cancellationToken);
    }
}