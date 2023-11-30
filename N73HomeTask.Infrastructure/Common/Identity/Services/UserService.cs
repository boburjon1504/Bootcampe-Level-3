using Microsoft.EntityFrameworkCore;
using N73HomeTask.Application.Common.Identity.Services;
using N73HomeTask.Domain.Entities;
using N73HomeTask.Domain.Enums;
using N73HomeTask.Persistense.Repostitories.Interfaces;

namespace N73HomeTask.Infrastructure.Common.Identity.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
    public ValueTask<IList<User>> GetByIdsAsync(
        IEnumerable<Guid> usersId,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
    ) =>
        userRepository.GetByIdsAsync(usersId, asNoTracking, cancellationToken);

    public async ValueTask<User?> GetSystemUserAsync(bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return await userRepository.Get(user => user.Role == RoleType.System, asNoTracking)
            .Include(user => user.UserSettings)
            .SingleOrDefaultAsync(cancellationToken);
    }

    public ValueTask<User?> GetByIdAsync(
        Guid userId,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
    ) =>
        userRepository.GetByIdAsync(userId, asNoTracking, cancellationToken);
}