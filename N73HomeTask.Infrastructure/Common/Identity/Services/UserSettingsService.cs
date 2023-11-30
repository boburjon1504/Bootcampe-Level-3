using N73HomeTask.Application.Common.Identity.Services;
using N73HomeTask.Domain.Entities;
using N73HomeTask.Persistense.Repostitories.Interfaces;

namespace N73HomeTask.Infrastructure.Common.Identity.Services;

public class UserSettingsService(IUserSettingsRepository userSettingsRepository) : IUserSettingsService
{
    public ValueTask<UserSettings?> GetByIdAsync(
        Guid userSettingsId,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
    ) =>
        userSettingsRepository.GetByIdAsync(userSettingsId, asNoTracking, cancellationToken);
}