using N73HomeTask.Domain.Entities;

namespace N73HomeTask.Persistense.Repostitories.Interfaces;

public interface IUserSettingsRepository
{
    ValueTask<UserSettings?> GetByIdAsync(
        Guid userId,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
    );
}