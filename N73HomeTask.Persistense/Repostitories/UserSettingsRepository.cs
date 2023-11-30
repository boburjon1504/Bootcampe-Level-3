using N73HomeTask.Domain.Entities;
using N73HomeTask.Persistense.DataAccess;
using N73HomeTask.Persistense.Repostitories.Interfaces;

namespace N73HomeTask.Persistense.Repostitories;

public class UserSettingsRepository(NotificationDbContext context) : 
    EntityRepositoryBase<UserSettings,NotificationDbContext>(context),IUserSettingsRepository
{
    public ValueTask<UserSettings?> GetByIdAsync(
        Guid userId,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
    ) =>
        base.GetByIdAsync(userId, asNoTracking, cancellationToken);
}