using N70HomeTask.Domain.Entities;
using N70HomeTask.Domain.Enums;

namespace N70HomeTask.Application.Service;

public interface IAuthService
{
    ValueTask<bool> RegisterAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default);
    ValueTask<string> LoginAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default);
    ValueTask<User> GrandRoleAsync(Guid userId, UserRole role,bool saveChanges = true, CancellationToken cancellationToken = default);
}