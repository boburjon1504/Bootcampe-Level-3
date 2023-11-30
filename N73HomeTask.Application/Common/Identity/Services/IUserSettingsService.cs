using N73HomeTask.Domain.Entities;

namespace N73HomeTask.Application.Common.Identity.Services;

public interface IUserSettingsService
{
    ValueTask<UserSettings?> GetByIdAsync(Guid userSettingsId, 
        bool asNoTracking = false, 
        CancellationToken cancellationToken = default);
}