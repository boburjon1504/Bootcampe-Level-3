using N70HomeTask.Application.Service;
using N70HomeTask.Domain.Entities;
using N70HomeTask.Persistense.Repositories.RoleRepositories;

namespace N70HomeTask.Infrastructure.Service;

public class RoleService(IRoleRepository roleRepository) : IRoleService
{
    public IQueryable<Role> Get(Func<Role, bool> predicate, bool asNoTracking = false)
    {
        return roleRepository.Get(predicate, asNoTracking);
    }

    public ValueTask<Role?> GetById(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return roleRepository.GetById(id,asNoTracking,cancellationToken);
    }

    public ValueTask<Role> CreateAsync(Role role, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return roleRepository.CreateAsync(role, saveChanges, cancellationToken);
    }

    public async ValueTask<Role> UpdateAsync(Role role, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var foundRole = await GetById(role.Id);
        return await roleRepository.UpdateAsync(foundRole, saveChanges, cancellationToken);
    }

    public async ValueTask<Role> DeleteAsync(Role role, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var foundRole = await GetById(role.Id);

        return await roleRepository.DeleteAsync(role, saveChanges, cancellationToken);
    }
}